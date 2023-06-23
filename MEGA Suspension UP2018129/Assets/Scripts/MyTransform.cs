using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTransform : MonoBehaviour
{
    Vector3[] modelVerts;

    MeshFilter mf;

    public MyVector3 positionVector = new MyVector3();
    public MyVector3 rotationVector = new MyVector3();
    public MyVector3 scaleVector = new MyVector3();

    public MyQuaternion quaternion = new MyQuaternion();

    public MyMatrix4x4 T;
    MyMatrix4x4 S;
    MyMatrix4x4 R;
    MyMatrix4x4 M;

    void Start()
    {
        mf = GetComponent<MeshFilter>();

        modelVerts = mf.mesh.vertices;
    }

    void Update()
    {

        Vector3[] transformedVerticies = new Vector3[modelVerts.Length];

        T = new MyMatrix4x4(new MyVector3(1,0,0),new MyVector3(0,1,0),new MyVector3(0,0,1),new MyVector3(positionVector.x,positionVector.y,positionVector.z));

        MyMatrix4x4 rotMatrixPitch = new MyMatrix4x4(new MyVector3(1, 0, 0), new MyVector3(0, Mathf.Cos(rotationVector.x), -Mathf.Sin(rotationVector.x)), new MyVector3(0, Mathf.Sin(rotationVector.x), Mathf.Cos(rotationVector.x)), new MyVector3());
        MyMatrix4x4 rotMatrixYaw = new MyMatrix4x4(new MyVector3(Mathf.Cos(rotationVector.y), 0, -Mathf.Sin(rotationVector.y)), new MyVector3(0, 1, 0), new MyVector3(Mathf.Sin(rotationVector.y), 0, Mathf.Cos(rotationVector.y)), new MyVector3());
        MyMatrix4x4 rotMatrixRoll = new MyMatrix4x4(new MyVector3(Mathf.Cos(rotationVector.z), -Mathf.Sin(rotationVector.z), 0), new MyVector3(Mathf.Sin(rotationVector.z), Mathf.Cos(rotationVector.z), 0), new MyVector3(0, 0, 1), new MyVector3());

        S = new MyMatrix4x4(new MyVector3(1, 0, 0) * scaleVector.x, new MyVector3(0, 1, 0) * scaleVector.y, new MyVector3(0, 0, 1) * scaleVector.z, new MyVector3());

        R = rotMatrixYaw * (rotMatrixPitch * rotMatrixRoll);

        M = NotInverseM();

        //M = NotInverseMq();

        //M = T * (R * S);

        //MyMatrix4x4 iM = S.InverseScale() * (R.InverseRotation() * T.InverseTranslation());



        //for (int i = 0; i < transformedVerticies.Length; i++)
        //{
        //    MyVector3 rollVert = rotMatrixRoll * MyVector3.UnityVector3ToMyVector3(modelVerts[i]);
        //    MyVector3 pitchVert = rotMatrixPitch * rollVert;
        //    MyVector3 yawVert = rotMatrixYaw * pitchVert;
        //
        //    transformedVerticies[i] = yawVert.MyVector3ToUnityVector3();
        //}

        //for(int i = 0; i< transformedVerticies.Length; i++)
        //{
        //    transformedVerticies[i] = MyVector4.ConverToVector3(scaleMatrix * new MyVector4(MyVector3.UnityVector3ToMyVector3(modelVerts[i]).x, MyVector3.UnityVector3ToMyVector3(modelVerts[i]).y, MyVector3.UnityVector3ToMyVector3(modelVerts[i]).z, 1f)).MyVector3ToUnityVector3();
        //}

        for (int i = 0; i< transformedVerticies.Length; i++)
        {
            transformedVerticies[i] = (M * MyVector3.UnityVector3ToMyVector3(modelVerts[i])).MyVector3ToUnityVector3();
        }

        mf.mesh.vertices = transformedVerticies;

        mf.mesh.RecalculateNormals();
        mf.mesh.RecalculateBounds();
    }

    public MyMatrix4x4 InverseM()
    {
        return S.InverseScale() * (R.InverseRotation() * T.InverseTranslation());
    }
    public MyMatrix4x4 NotInverseM()
    {
        return T * (R * S);
    }

    public MyMatrix4x4 NotInverseMq()
    {
        return (T * (QtoR(quaternion) * S));
    }

    public MyMatrix4x4 QtoR(MyQuaternion q)
    {
        MyMatrix4x4 rv = new MyMatrix4x4();

        //rv.values[0,0] = 2 * (q.w * q.w + q.v.x * q.v.x) - 1;
        //rv.values[0,1] = 2 * (q.v.x * q.v.y - q.w * q.v.z);
        //rv.values[0,2] = 2 * (q.v.x * q.v.z + q.w * q.v.y);
        //rv.values[0,3] = 1;

        //rv.values[1,0] = 2 * (q.v.x * q.v.y + q.w * q.v.z);
        //rv.values[1,1] = 2 * (q.w * q.w + q.v.y * q.v.y) - 1;
        //rv.values[1,2] = 2 * (q.v.y * q.v.z - q.w * q.v.x);
        //rv.values[1,3] = 1;

        //rv.values[2,0] = 2 * (q.v.x * q.v.z - q.w * q.v.y);
        //rv.values[2,1] = 2 * (q.v.y * q.v.z + q.w * q.v.x);
        //rv.values[2,2] = 2 * (q.w * q.w + q.v.z * q.v.z) - 1;
        //rv.values[2,3] = 1;

        //rv.values[3,0] = 0;
        //rv.values[3,1] = 0;
        //rv.values[3,2] = 0;
        //rv.values[3,3] = 1;

        //return rv;

        float wx, wy, wz, xx, yy, yz, xy, xz, zz, x2, y2, z2;

        x2 = q.v.x + q.v.x; y2 = q.v.y + q.v.y;
        z2 = q.v.z + q.v.z;
        xx = q.v.x * x2; xy = q.v.x * y2; xz = q.v.x * z2;
        yy = q.v.y * y2; yz = q.v.y * z2; zz = q.v.z * z2;
        wx = q.w * x2; wy = q.w * y2; wz = q.w * z2;

        rv.values[0,0] = 1.0f - (yy + zz); 
        rv.values[1,0] = xy - wz;
        rv.values[2,0] = xz + wy;
        rv.values[3,0] = 0.0f;

        rv.values[0,1] = xy + wz; 
        rv.values[1,1] = 1.0f - (xx + zz);
        rv.values[2,1] = yz - wx;
        rv.values[3, 1] = 0.0f;

        rv.values[0,2] = xz - wy; 
        rv.values[1,2] = yz + wx;
        rv.values[2,2] = 1.0f - (xx + yy);
        rv.values[3,2] = 0.0f;

        rv.values[0,3] = 0; 
        rv.values[1,3] = 0;
        rv.values[2,3] = 0;
        rv.values[3,3] = 0;

        return rv;
    }

}

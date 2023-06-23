using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsLib
{
    public static float Vector2ToRadians(MyVector2 vector)
    {
        float result;

        result = Mathf.Atan(vector.y / vector.x);

        //result = Mathf.Atan2(vector.y,vector.x);//other method

        return result;
    }

    public static float Vector2ToRadians(Vector2 vector)
    {
        float result;

        result = Mathf.Atan(vector.y / vector.x);

        //result = Mathf.Atan2(vector.y,vector.x);//other method

        return result;
    }

    public static MyVector2 RadiansToMyVector2(float angle)
    {
        MyVector2 result = new MyVector2(Mathf.Cos(angle), Mathf.Sin(angle));

        //result.x = Mathf.Cos(angle);
        //result.y = Mathf.Sin(angle);

        return result;
    }

    public static Vector2 RadiansToVector2(float angle)
    {
        Vector2 result = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        //result.x = Mathf.Cos(angle);
        //result.y = Mathf.Sin(angle);

        return result;
    }

    public static MyVector3 EulerAnglesToDirection(MyVector3 EulerAngles)
    {
        MyVector3 result = new MyVector3();
        //Make sure the values stored inside "EulerAngles" are in RADIANS
        result.x = Mathf.Cos(-EulerAngles.x) * Mathf.Sin(EulerAngles.y);
        result.y = Mathf.Sin(-EulerAngles.x);
        result.z = Mathf.Cos(EulerAngles.y) * Mathf.Cos(-EulerAngles.x);
        return result;
    }

    public static Vector3 EulerAnglesToDirection(Vector3 EulerAngles)
    {
        Vector3 result = new Vector3();
        //Make sure the values stored inside "EulerAngles" are in RADIANS
        result.x = Mathf.Cos(-EulerAngles.x) * Mathf.Sin(EulerAngles.y);
        result.y = Mathf.Sin(-EulerAngles.x);
        result.z = Mathf.Cos(EulerAngles.y) * Mathf.Cos(-EulerAngles.x);
        return result;
    }

    public static MyVector3 MyVector3CrosProduct(MyVector3 vector1, MyVector3 vector2)
    {
        MyVector3 result = new MyVector3();

        result.x = vector1.y * vector2.z - vector1.z * vector2.y;
        result.y = vector1.z * vector2.x - vector1.x * vector2.z;
        result.z = vector1.x * vector2.y - vector1.y * vector2.x;

        return result;
    }

    public static Vector3 Vector3CrosProduct(Vector3 vector1, Vector3 vector2)
    {
        Vector3 result = new Vector3();

        result.x = vector1.y * vector2.z - vector1.z * vector2.y;
        result.y = vector1.z * vector2.x - vector1.x * vector2.z;
        result.z = vector1.x * vector2.y - vector1.y * vector2.x;

        return result;
    }

    public static MyVector2 MyLerp(MyVector2 vector1,   MyVector2 vector2, float t)
    {
        MyVector2 result;

        result = vector1 * (1f - t) + vector2 * t;

        return result;
    }

    public static MyVector3 MyLerp(MyVector3 vector1, MyVector3 vector2, float t)
    {
        MyVector3 result;

        result = vector1 * (1f - t) + vector2 * t;

        return result;
    }

    public static MyVector3 RotateVertex(float angle, MyVector3 axis, MyVector3 vertex)
    {
        MyVector3 rv = vertex * Mathf.Cos(angle) + axis * MyVector3.DotProduct(vertex, axis) * (1.0f - Mathf.Cos(angle)) + MyVector3CrosProduct(axis,vertex) * Mathf.Sin(angle);

        return rv;
    }
}

public class MyMatrix4x4
{
            //column 1        //column 2         //column 3        //column 4     
    //row1  //values[0, 0] = 0; values[0, 1] = 0;  values[0, 2] = 0; values[0, 3] = 0; 
    //row2  //values[1, 0] = 0; values[1, 1] = 0;  values[1, 2] = 0; values[1, 3] = 0; 
    //row3  //values[2, 0] = 0; values[2, 1] = 0;  values[2, 2] = 0; values[2, 3] = 0; 
    //row4  //values[3, 0] = 0; values[3, 1] = 0;  values[3, 2] = 0; values[3, 3] = 0;   

    public float[,] values = new float[4, 4];

    public MyMatrix4x4()
    {
        //column 1
        values[0, 0] = 0;
        values[1, 0] = 0;
        values[2, 0] = 0;
        values[3, 0] = 0;
        //column 2     0;
        values[0, 1] = 0;
        values[1, 1] = 0;
        values[2, 1] = 0;
        values[3, 1] = 0;
        //column 3     0;
        values[0, 2] = 0;
        values[1, 2] = 0;
        values[2, 2] = 0;
        values[3, 2] = 0;
        //column 4     0;
        values[0, 3] = 0;
        values[1, 3] = 0;
        values[2, 3] = 0;
        values[3, 3] = 0;
    }

    public MyMatrix4x4(MyVector3 column1, MyVector3 column2, MyVector3 column3, MyVector3 column4)
    {
        //column 1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0;
        //column 2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;
        //column 3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;
        //column 4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }
    public MyMatrix4x4(MyVector4 column1, MyVector4 column2, MyVector4 column3, MyVector4 column4)
    {
        //column 1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;
        //column 2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;
        //column 3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;
        //column 4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;
    }

    public static MyMatrix4x4 Identity
    {
        get
        {
            return new MyMatrix4x4(new MyVector4(1, 0, 0, 0), new MyVector4(0, 1, 0, 0), new MyVector4(0, 0, 1, 0), new MyVector4(0, 0, 0, 1));
        }
    }

    public MyVector4 GetRow(int row)
    {
        MyVector4 rv = new MyVector4();

        rv.x = values[row, 0];
        rv.y = values[row, 1];
        rv.z = values[row, 2];
        rv.w = values[row, 3];

        return rv;
    }

    public MyMatrix4x4 InverseTranslation()
    {
        MyMatrix4x4 rv = Identity;

        rv.values[0, 3] = -values[0, 3];
        rv.values[1, 3] = -values[1, 3];
        rv.values[2, 3] = -values[2, 3];

        return rv;
    }

    public MyMatrix4x4 InverseRotation()
    {
        return new MyMatrix4x4(GetRow(0), GetRow(1), GetRow(2), GetRow(3));
    }

    public MyMatrix4x4 InverseScale()
    {
        MyMatrix4x4 rv = Identity;

        rv.values[0, 0] = 1.0f / values[0, 0];
        rv.values[1, 1] = 1.0f / values[1, 1];
        rv.values[2, 2] = 1.0f / values[2, 2];

        return rv;
    }

    public static MyVector3 MatrixMultiplication(MyMatrix4x4 lhs, MyVector3 vector)
    {
        MyVector3 result = new MyVector3();

        result.x = vector.x * lhs.values[0, 0] + vector.y * lhs.values[0, 1] + vector.z * lhs.values[0, 2] + 1 * lhs.values[0, 3];
        result.y = vector.x * lhs.values[1, 0] + vector.y * lhs.values[1, 1] + vector.z * lhs.values[1, 2] + 1 * lhs.values[1, 3];
        result.z = vector.x * lhs.values[2, 0] + vector.y * lhs.values[2, 1] + vector.z * lhs.values[2, 2] + 1 * lhs.values[2, 3];

        return result;
    }
    public static MyVector4 MatrixMultiplication(MyMatrix4x4 lhs, MyVector4 vector)
    {
        MyVector4 result = new MyVector4();

        result.x = vector.x * lhs.values[0, 0] + vector.y * lhs.values[0, 1] + vector.z * lhs.values[0, 2] + vector.w * lhs.values[0, 3];
        result.y = vector.x * lhs.values[1, 0] + vector.y * lhs.values[1, 1] + vector.z * lhs.values[1, 2] + vector.w * lhs.values[1, 3];
        result.z = vector.x * lhs.values[2, 0] + vector.y * lhs.values[2, 1] + vector.z * lhs.values[2, 2] + vector.w * lhs.values[2, 3];
        result.w = vector.x * lhs.values[3, 0] + vector.y * lhs.values[3, 1] + vector.z * lhs.values[3, 2] + vector.w * lhs.values[3, 3];

        return result;
    }

    public static MyMatrix4x4 MatrixMultiplication(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
    {
        MyMatrix4x4 result = new MyMatrix4x4();

        //result.values[0,0] = lhs.values[0,0] * rhs.values[0,0] + lhs.values[0,1] * rhs.values[1,0] + lhs.values[0,2] * rhs.values[2,0] + lhs.values[0,3] * rhs.values[3,0];
        //result.values[1,0] = lhs.values[1,0] * rhs.values[0,0] + lhs.values[1,1] * rhs.values[1,0] + lhs.values[1,2] * rhs.values[2,0] + lhs.values[1,3] * rhs.values[3,0];
        //result.values[2,0] = lhs.values[2,0] * rhs.values[0,0] + lhs.values[2,1] * rhs.values[1,0] + lhs.values[2,2] * rhs.values[2,0] + lhs.values[2,3] * rhs.values[3,0];
        //result.values[3,0] = lhs.values[3,0] * rhs.values[0,0] + lhs.values[3,1] * rhs.values[1,0] + lhs.values[3,2] * rhs.values[2,0] + lhs.values[3,3] * rhs.values[3,0];

        //result.values[0,1] = lhs.values[0,0] * rhs.values[0,1] + lhs.values[0,1] * rhs.values[1,1] + lhs.values[0,2] * rhs.values[2,1] + lhs.values[0,3] * rhs.values[3,1];
        //result.values[1,1] = lhs.values[1,0] * rhs.values[0,1] + lhs.values[1,1] * rhs.values[1,1] + lhs.values[1,2] * rhs.values[2,1] + lhs.values[1,3] * rhs.values[3,1];
        //result.values[2,1] = lhs.values[2,0] * rhs.values[0,1] + lhs.values[2,1] * rhs.values[1,1] + lhs.values[2,2] * rhs.values[2,1] + lhs.values[2,3] * rhs.values[3,1];
        //result.values[3,1] = lhs.values[3,0] * rhs.values[0,1] + lhs.values[3,1] * rhs.values[1,1] + lhs.values[3,2] * rhs.values[2,1] + lhs.values[3,3] * rhs.values[3,1];

        //result.values[0,2] = lhs.values[0,0] * rhs.values[0,2] + lhs.values[0,1] * rhs.values[1,2] + lhs.values[0,2] * rhs.values[2,2] + lhs.values[0,3] * rhs.values[3,2];
        //result.values[1,2] = lhs.values[1,0] * rhs.values[0,2] + lhs.values[1,1] * rhs.values[1,2] + lhs.values[1,2] * rhs.values[2,2] + lhs.values[1,3] * rhs.values[3,2];
        //result.values[2,2] = lhs.values[2,0] * rhs.values[0,2] + lhs.values[2,1] * rhs.values[1,2] + lhs.values[2,2] * rhs.values[2,2] + lhs.values[2,3] * rhs.values[3,2];
        //result.values[3,2] = lhs.values[3,0] * rhs.values[0,2] + lhs.values[3,1] * rhs.values[1,2] + lhs.values[3,2] * rhs.values[2,2] + lhs.values[3,3] * rhs.values[3,2];

        //result.values[1,3] = lhs.values[1,0] * rhs.values[0,3] + lhs.values[1,1] * rhs.values[1,3] + lhs.values[1,2] * rhs.values[2,3] + lhs.values[1,3] * rhs.values[3,3];
        //result.values[2,3] = lhs.values[2,0] * rhs.values[0,3] + lhs.values[2,1] * rhs.values[1,3] + lhs.values[2,2] * rhs.values[2,3] + lhs.values[2,3] * rhs.values[3,3];
        //result.values[0,3] = lhs.values[0,0] * rhs.values[0,3] + lhs.values[0,1] * rhs.values[1,3] + lhs.values[0,2] * rhs.values[2,3] + lhs.values[0,3] * rhs.values[3,3];
        //result.values[3,3] = lhs.values[3,0] * rhs.values[0,3] + lhs.values[3,1] * rhs.values[1,3] + lhs.values[3,2] * rhs.values[2,3] + lhs.values[3,3] * rhs.values[3,3];


                //column 1          //column 2         //column 3        //column 4     
        //row1  //values[0, 0] = 0; values[0, 1] = 0;  values[0, 2] = 0; values[0, 3] = 0;
        //row2  //values[1, 0] = 0; values[1, 1] = 0;  values[1, 2] = 0; values[1, 3] = 0;
        //row3  //values[2, 0] = 0; values[2, 1] = 0;  values[2, 2] = 0; values[2, 3] = 0;
        //row4  //values[3, 0] = 0; values[3, 1] = 0;  values[3, 2] = 0; values[3, 3] = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result.values[i, j] = lhs.values[i, 0] * rhs.values[0, j] + lhs.values[i, 1] * rhs.values[1, j] + lhs.values[i, 2] * rhs.values[2, j] + lhs.values[i, 3] * rhs.values[3, j];
            }
        }

        return result;
    }

    public static MyVector3 operator *(MyMatrix4x4 lhs, MyVector3 vector)
    {
        return MatrixMultiplication(lhs, vector);
    }
    
    public static MyVector4 operator*(MyMatrix4x4 lhs, MyVector4 vector)
    {
        return MatrixMultiplication(lhs, vector);
    }

    public static MyMatrix4x4 operator *(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
    {
        return MatrixMultiplication(lhs, rhs);
    }
}

[System.Serializable]
public class MyQuaternion
{
    public float w;
    public MyVector3 v;

    public MyQuaternion()
    {
        w = 0.0f;
        v = new MyVector3();
    }

    public MyQuaternion(float angle,MyVector3 axis)
    {
        float halfAngle = angle / 2;

        w = Mathf.Cos(halfAngle);

        v = axis * Mathf.Sin(halfAngle);

        //x = axis.x * Mathf.Sin(halfAngle);
        //y = axis.y * Mathf.Sin(halfAngle);
        //z = axis.z * Mathf.Sin(halfAngle);
    }

    public MyQuaternion(MyVector3 position)
    {
        w = 0f;
        v = new MyVector3(position.x, position.y, position.z);
    }

    public static MyQuaternion operator*(MyQuaternion lhs,MyQuaternion rhs)
    {
        MyQuaternion rv = new MyQuaternion(lhs.w * rhs.w - MyVector3.DotProduct(lhs.v,rhs.v),rhs.v * lhs.w + lhs.v * rhs.w + MathsLib.MyVector3CrosProduct(rhs.v,lhs.v));

        return rv;
    }

    public void SetAxis(MyVector3 axis)
    {
        v = axis;
    }
    public MyVector3 GetAxis()
    {
        return v;
    }

    public MyQuaternion Inverse()
    {
        MyQuaternion rv = new MyQuaternion();

        rv.w = w;

        rv.SetAxis(GetAxis() * -1);

        return rv;
    }
}
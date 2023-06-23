using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public GameObject floor;

    public MyTransform trans;

    public MyVector3[] springLoc = new MyVector3[4];

    public float suspensionLength;
    public float suspensionLengthOld;

    public float suspensionMaxLength;
    public float suspensionMinLength;

    public float suspensionTravel;

    public float restLength;

    public float stiffness;

    public float dampingStiffness;

    float dampingForce;

    MyVector3 finalForce;

    MyRigidbody mrb;

    MyVector3 localStart = new MyVector3();
    MyVector3 localEnd = new MyVector3();

    MyVector3 localBoxMin = new MyVector3();
    MyVector3 localBoxMax = new MyVector3();

    public bool physicsraycast;
    void Start()
    {
        trans = gameObject.GetComponent<MyTransform>();
        mrb = gameObject.GetComponent<MyRigidbody>();

        suspensionMinLength = restLength - suspensionTravel;
        suspensionMaxLength = restLength + suspensionTravel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AABB box = new AABB(new MyVector3(0, 0, 0), new MyVector3(3, 3, 3));

        for (int i = 0; i < springLoc.Length; i++)
        {
            //Debug.Log("start spring" + (springLoc[i] + trans.positionVector).MyVector3ToUnityVector3());
            //Debug.Log("end spring" + ((springLoc[i] + trans.positionVector) + ((MyVector3.up * -1) * suspensionMaxLength)).MyVector3ToUnityVector3());
            //Debug.Log("min floor" + floor.GetComponent<Colider>().box.minExtent.MyVector3ToUnityVector3());
            //Debug.Log("max floor" + floor.GetComponent<Colider>().box.maxExtent.MyVector3ToUnityVector3());

            localStart = trans.InverseM() * (springLoc[i] + trans.positionVector);
            localEnd = trans.InverseM() * (springLoc[i] + trans.positionVector) + ((MyVector3.up * -1) * suspensionMaxLength);

            localBoxMin = trans.InverseM() * floor.GetComponent<Colider>().box.minExtent;
            localBoxMax = trans.InverseM() * floor.GetComponent<Colider>().box.maxExtent;

            //Debug.Log("Start" + (springLoc[i] + trans.positionVector).MyVector3ToUnityVector3());
            //Debug.Log("End" + ((springLoc[i] + trans.positionVector) + ((MyVector3.up * -1) * suspensionMaxLength)).MyVector3ToUnityVector3());

            MyVector3 result;

            finalForce = new MyVector3(0,0,0);

            if (!physicsraycast)
            {
                if (AABB.LineIntersection(new AABB(localBoxMin,localBoxMax), localStart, localEnd, out result))
                {
                    //Debug.Log("Intersecting! local intersection point: " + result.MyVector3ToUnityVector3());
                    //Debug.Log("Global Intersection point: " + result.MyVector3ToUnityVector3());

                    result = trans.NotInverseM() * result;

                    suspensionLengthOld = suspensionLength;

                    //suspensionLength = ((springLoc[i] + trans.positionVector) - result).Vector3Magnitude();

                    suspensionLength = result.Vector3Magnitude();

                    //Debug.Log("its coliding");

                    suspensionLength = Mathf.Clamp(suspensionLength, suspensionMinLength, suspensionMaxLength);

                    dampingForce = dampingStiffness * Acceleration(suspensionLengthOld, suspensionLength, Time.fixedDeltaTime);

                    finalForce = MyVector3.UnityVector3ToMyVector3((HookesLaw(stiffness, restLength - suspensionLength) + dampingForce) * transform.up);

                    mrb.Addforce(finalForce);

                }
            }
            else
            {
                if (Physics.Raycast((springLoc[i] + trans.positionVector).MyVector3ToUnityVector3(), -transform.up, out RaycastHit intersectpoint, suspensionMaxLength))
                {
                    //Debug.Log("Intersecting! local intersection point: " + result.MyVector3ToUnityVector3());
                    //Debug.Log("Global Intersection point: " + result.MyVector3ToUnityVector3());

                    suspensionLengthOld = suspensionLength;

                    suspensionLength = intersectpoint.distance;

                    suspensionLength = Mathf.Clamp(suspensionLength, suspensionMinLength, suspensionMaxLength);

                    dampingForce = dampingStiffness * Acceleration(suspensionLengthOld, suspensionLength, Time.fixedDeltaTime);

                    finalForce = MyVector3.UnityVector3ToMyVector3((HookesLaw(stiffness, restLength - suspensionLength) + dampingForce) * transform.up);

                    mrb.Addforce(finalForce);

                }
            }

        }

        
    }



    /// <summary>
    /// Calcualtes Hookes Law
    /// </summary>
    /// <param name="K">is the Spring Constant(stiffnes)</param>
    /// <param name="X">is the Compression/Extension </param>
    /// <returns> </returns>
    float HookesLaw(float K, float X)
    {
        float F = K * X;//need negative K for when I want an extension spring not when I want compression spring
        return F;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lasPos"></param>
    /// <param name="curentPos"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    float Acceleration(float lasPos, float curentPos, float t)
    {
        float a = (lasPos - curentPos) / t;
        return a;
    }
}

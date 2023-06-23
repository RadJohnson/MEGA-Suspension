using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( MyTransform))]
public class MyRigidbody : MonoBehaviour
{
    public MyVector3 Force = new MyVector3(0,0,0);
    MyVector3 acceleration = new MyVector3(0,0,0);
    MyVector3 velocity = new MyVector3(0,0,0);
    public float Mass = 1;
    public float gravity;

    MyTransform trans;

    void Start()
    {
        trans = GetComponent<MyTransform>();
    }

    private void FixedUpdate()
    {
        //Force += new MyVector3(0,gravity,0);

        acceleration = Force / Mass;

        velocity += acceleration * Time.fixedDeltaTime + new MyVector3(0, gravity, 0) * Time.fixedDeltaTime;

        trans.positionVector += velocity * Time.fixedDeltaTime;

        Force = new MyVector3(0,0,0);

        //Debug.Log(Force);
    }

    public void Addforce(MyVector3 forceToAdd)
    {
        Force += forceToAdd;
    }
}

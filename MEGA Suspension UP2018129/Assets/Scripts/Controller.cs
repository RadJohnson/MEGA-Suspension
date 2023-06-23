using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    MyVector2 movementInput = new MyVector2();
    MyVector2 rotationInput = new MyVector2();

    [SerializeField]
    private float moveSpeed;

    MyVector3 moveDir = new MyVector3();

    MyVector3 forwardDir = new MyVector3();

    MyVector3 rightDir = new MyVector3();


    void Update()
    {
        rotationInput.y -= Input.GetAxisRaw("Mouse Y");
        rotationInput.x += Input.GetAxisRaw("Mouse X");

        transform.rotation = Quaternion.Euler(rotationInput.y, rotationInput.x, 0);

        //movementInput.y = Input.GetAxisRaw("Horizontal");
        //movementInput.x = Input.GetAxisRaw("Vertical");


        Debug.Log(MathsLib.EulerAnglesToDirection(transform.rotation.eulerAngles));

        //Vector3 moveDir = (movementInput.x * transform.forward + movementInput.y * transform.right);


        forwardDir = MyVector3.UnityVector3ToMyVector3(MathsLib.EulerAnglesToDirection(Mathf.Deg2Rad * transform.rotation.eulerAngles));

        rightDir = MyVector3.UnityVector3ToMyVector3(MathsLib.Vector3CrosProduct(Vector3.up, forwardDir.MyVector3ToUnityVector3()));

        //(movementInput.x * dirFacing.x + movementInput.y * dirFacing.z);

        if (Input.GetKey("w"))
        {
            transform.position += (forwardDir * moveSpeed * Time.deltaTime).MyVector3ToUnityVector3();
        }
        if (Input.GetKey("d"))
        {
            transform.position += (rightDir * moveSpeed * Time.deltaTime).MyVector3ToUnityVector3();

        }
        if (Input.GetKey("s"))
        {
            transform.position -= (forwardDir * moveSpeed * Time.deltaTime).MyVector3ToUnityVector3();
        }
        if (Input.GetKey("a"))
        {
            transform.position -= (rightDir * moveSpeed * Time.deltaTime).MyVector3ToUnityVector3();

        }
    }
}

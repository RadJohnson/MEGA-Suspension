using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateGameObject : MonoBehaviour
{
    [SerializeField]
    private Transform targetObj;
    [SerializeField]
    private string objectToDetect;
    
    private MyVector3 myPos;
    private MyVector3 targetPos;

    [SerializeField, Range(0, 10)]
    private float moveSpeed;

    private void Start()
    {
        //targetPos = GameObject.FindGameObjectWithTag(objectToDetect).transform;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    myPos = new MyVector3(transform.position.x, transform.position.y, transform.position.z);

        //    targetPos = new MyVector3(targetObj.position.x, targetObj.position.y, targetObj.position.z);

        //    MyVector3 distFromTarget = MyVector3.SubtractVector3(targetPos, myPos);

        //    MyVector3 distToMove = MyVector3.AddVector3(myPos, distFromTarget);

        //    transform.position = distToMove.MyVector3ToUnityVector3();
        //}

        myPos = new MyVector3(transform.position.x, transform.position.y, transform.position.z);

        targetPos = new MyVector3(targetObj.position.x, targetObj.position.y, targetObj.position.z);

        MyVector3 distToMove = targetPos - myPos;

        transform.position += (distToMove.MyVector3ToUnityVector3() * moveSpeed) * Time.deltaTime;

        //MyVector3 distFromTarget = MyVector3.SubtractVector3(targetPos, myPos);

        //MyVector3 distToMove = MyVector3.NormaliseVector3(MyVector3.AddVector3(myPos, distFromTarget));

        //transform.position += (distToMove.MyVector3ToUnityVector3() * moveSpeed) * Time.deltaTime;
    }
}

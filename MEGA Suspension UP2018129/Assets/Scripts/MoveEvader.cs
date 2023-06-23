using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEvader : MonoBehaviour
{
    [SerializeField,Range(2,8)]
    private float timerLength;
    
    private float timer;

    [SerializeField]
    private Vector2 horizontalBounds;

    [SerializeField]
    private Vector2 verticalBounds;

    private MyVector3 myPos;

    void Awake()
    {
        myPos = new MyVector3();
    }

    void Update()
    {
        if(timer <= 0)
        {
            myPos = new MyVector3(Random.Range(horizontalBounds.x, horizontalBounds.y),0, Random.Range(verticalBounds.x, verticalBounds.y));

            transform.position = myPos.MyVector3ToUnityVector3();

            timer = timerLength;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}

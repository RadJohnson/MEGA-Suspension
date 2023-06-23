using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider : MonoBehaviour
{
    public AABB box;
    private void Update()
    {
        box = new AABB(new MyVector3(-100, -1, -100), new MyVector3(100, 1, 100));
    }
}

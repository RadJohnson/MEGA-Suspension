using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AABB
{
    public MyVector3 minExtent;
    public MyVector3 maxExtent;

    public AABB(MyVector3 min, MyVector3 max)
    {
        minExtent = min;
        maxExtent = max;
    }

    public float Top
    {
        get { return maxExtent.y; }
    }
    public float Bottom
    {
        get { return minExtent.y; }
    }
    public float Left
    {
        get { return minExtent.x; }
    }
    public float Right
    {
        get { return maxExtent.x; }
    }
    public float Front
    {
        get { return maxExtent.z; }
    }
    public float Back

    {
        get { return minExtent.z; }
    }

    public static bool Intersects(AABB box1, AABB box2)
    {
        return !(
                  box1.Left > box1.Right || box2.Right < box1.Left
               || box2.Top < box1.Bottom || box2.Bottom > box1.Top
               || box2.Back > box1.Front || box2.Front < box1.Front
               );
    }

    public static bool LineIntersection(AABB box, MyVector3 startPoint, MyVector3 endPoint, out MyVector3 intersectionPoint)
    {
        float lowest = 0.0f;
        float highest = 1.0f;

        intersectionPoint = new MyVector3(0,0,0);

        if (!IntersectingAxis(MyVector3.right, box, startPoint, endPoint, ref lowest, ref highest))
            return false;

        if (!IntersectingAxis(MyVector3.up, box, startPoint, endPoint, ref lowest, ref highest))
            return false;

        if (!IntersectingAxis(MyVector3.forward, box, startPoint, endPoint, ref lowest, ref highest))
            return false;

        intersectionPoint = MathsLib.MyLerp(startPoint, endPoint, lowest);

        return true;
    }

    public static bool IntersectingAxis(MyVector3 Axis, AABB box, MyVector3 startPoint, MyVector3 endPoint, ref float lowest, ref float highest)
    {
        float minimum = 0.0f;
        float maximum = 1.0f;

        if (Axis == MyVector3.right)
        {
            minimum = (box.Left - startPoint.x) / (endPoint.x - startPoint.x);
            maximum = (box.Right - startPoint.x) / (endPoint.x - startPoint.x);
        }
        if (Axis == MyVector3.up)
        {
            minimum = (box.Bottom - startPoint.y) / (endPoint.y - startPoint.y);
            maximum = (box.Top - startPoint.y) / (endPoint.y - startPoint.y);
        }
        if (Axis == MyVector3.forward)
        {
            minimum = (box.Back - startPoint.z) / (endPoint.z - startPoint.z);
            maximum = (box.Front - startPoint.z) / (endPoint.z - startPoint.z);
        }

        if (maximum < minimum)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
        }

        if (maximum < lowest)
            return false;

        if (minimum > highest)
            return false;

        lowest = Mathf.Max(minimum, lowest);
        highest = Mathf.Min(maximum, highest);

        if (lowest > highest)
            return false;

        return true;
    }
}
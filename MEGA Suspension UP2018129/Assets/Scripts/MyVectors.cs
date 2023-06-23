using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MyVector2
    {
        public float x, y = 0f;
        public MyVector2()
        {
            x = 0;
            y = 0;
        }
        public MyVector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public static MyVector2 AddVector2(MyVector2 vector1, MyVector2 vector2)
        {
            MyVector2 result = new MyVector2();

            result.x = vector1.x + vector2.x;
            result.y = vector1.y + vector2.y;

            return result;
        }

        public static MyVector2 SubtractVector2(MyVector2 vector1, MyVector2 vector2)
        {
            MyVector2 result = new MyVector2();

            result.x = vector1.x - vector2.x;
            result.y = vector1.y - vector2.y;

            return result;
        }


        public static MyVector2 MultiplyVector2(MyVector2 vector1, float scalar)
        {
            MyVector2 result = new MyVector2();

            result.x = vector1.x * scalar;
            result.y = vector1.y * scalar;

            return result;
        }

        public static MyVector2 DivideVector2(MyVector2 vector1, float divisor)
        {
            MyVector2 result = new MyVector2();

            result.x = vector1.x / divisor;
            result.y = vector1.y / divisor;
 
            return result;
        }

        public static MyVector2 NormaliseVector2(MyVector2 vector)
        {
            MyVector2 result = vector;

            result = MyVector2.DivideVector2(vector, result.Vector2Magnitude());

            return result;
        }

        public static float DotProduct(MyVector2 vector1, MyVector2 vector2, bool shouldNormalise = true)
        {
            float result;

            MyVector2 vec1 = vector1;
            MyVector2 vec2 = vector2;

            if (shouldNormalise)
            {
                vec1 = MyVector2.NormaliseVector2(vec1);
                vec2 = MyVector2.NormaliseVector2(vec2);
            }

            result = vec1.x * vec2.x + vec1.y * vec2.y;

            return result;
        }

        public static float Vector2MagnitudeSqrd(MyVector2 vector)
        {
            float magnitudeSqrd;

            magnitudeSqrd = vector.x * vector.x + vector.y * vector.y;

            return magnitudeSqrd;
        }

        public float Vector2Magnitude()
        {
            float magnitude;

            magnitude = Mathf.Sqrt((x * x) + (y * y));

            return magnitude;
        }

        public Vector2 MyVector2ToUnityVector2()
        {
            Vector2 unityVector2 = new Vector2();

            unityVector2.x = x;
            unityVector2.y = y;

            return unityVector2;
        }

        public MyVector2 UnityVector2ToMyVector2(Vector2 unityVector2)
        {
            MyVector2 myVector2 = new MyVector2();

            myVector2.x = unityVector2.x;
            myVector2.y = unityVector2.y;

            return myVector2;
        }

        public static MyVector2 operator +(MyVector2 vector1, MyVector2 vector2)
        {
            return AddVector2(vector1, vector2);
        }
        public static MyVector2 operator -(MyVector2 vector1, MyVector2 vector2)
        {
            return SubtractVector2(vector1, vector2);
        }
        public static MyVector2 operator *(MyVector2 vector1, float scalar)
        {
            return MultiplyVector2(vector1, scalar);
        }
        public static MyVector2 operator /(MyVector2 vector1, float divisor)
        {
            return MultiplyVector2(vector1, divisor);
        }
    }

    [System.Serializable]
    public class MyVector3
    {
        public float x, y, z = 0f;
        public MyVector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public MyVector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        
        public static MyVector3 right
        {
            get
            {
                return new MyVector3(0, 0, 1);
            }
        }
        public static MyVector3 up
        {
            get
            {
                return new MyVector3(0,1,0); 
            }
        }    
        public static MyVector3 forward
        {
            get
            {
                return new MyVector3(1,0,0); 
            }
        }

        public static MyVector3 AddVector3(MyVector3 vector1, MyVector3 vector2)
        {
            MyVector3 result = new MyVector3();

            result.x = vector1.x + vector2.x;
            result.y = vector1.y + vector2.y;
            result.z = vector1.z + vector2.z;

            return result;
        }
        
        
        public static MyVector3 SubtractVector3(MyVector3 vector1, MyVector3 vector2)
        {
            MyVector3 result = new MyVector3();

            result.x = vector1.x - vector2.x;
            result.y = vector1.y - vector2.y;
            result.z = vector1.z - vector2.z;

            return result;
        }


        public static MyVector3 MultiplyVector3(MyVector3 vector1, float scalar)
        {
            MyVector3 result = new MyVector3();

            result.x = vector1.x * scalar;
            result.y = vector1.y * scalar;
            result.z = vector1.z * scalar;

            return result;
        }
        
        public static MyVector3 MultiplyVector3(MyVector3 vector1, MyVector3 scalar)
        {
            MyVector3 result = new MyVector3();

            result.x = vector1.x * scalar.x;
            result.y = vector1.y * scalar.y;
            result.z = vector1.z * scalar.z;

            return result;
        }


        public static MyVector3 DivideVector3(MyVector3 vector1, float divisor)
        {
            MyVector3 result = new MyVector3();

            result.x = vector1.x / divisor;
            result.y = vector1.y / divisor;
            result.z = vector1.z / divisor;

            return result;
        }

        public static MyVector3 NormaliseVector3(MyVector3 vector)
        {
            MyVector3 result = vector;

            result = MyVector3.DivideVector3(result , result.Vector3Magnitude());

            return result;
        }

        public static float DotProduct(MyVector3 vector1, MyVector3 vector2, bool shouldNormalise = true)
        {
            float result;

            MyVector3 vec1 = vector1;
            MyVector3 vec2 = vector2;

            if (shouldNormalise)
            {
                vec1 = MyVector3.NormaliseVector3(vec1);
                vec2 = MyVector3.NormaliseVector3(vec2);
            }

            result = vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;

            return result;
        }

        public static float Vector3MagnitudeSqrd(MyVector3 vector)
        {
            float magnitudeSqrd;

            magnitudeSqrd = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;

            return magnitudeSqrd;
        }

        public float Vector3Magnitude()
        {
            float magnitude;

            magnitude = Mathf.Sqrt((x * x) + (y * y) + (z * z));

            return magnitude;
        }

        public Vector3 MyVector3ToUnityVector3()
        {
            Vector3 unityVector3 = new Vector3();

            unityVector3.x = x;
            unityVector3.y = y;
            unityVector3.z = z;

            return unityVector3;
        }

        public static MyVector3 UnityVector3ToMyVector3(Vector3 unityVector3)
        {
            MyVector3 myVector3 = new MyVector3();

            myVector3.x = unityVector3.x;
            myVector3.y = unityVector3.y;
            myVector3.z = unityVector3.z;

            return myVector3;
        }

        public static MyVector3 operator +(MyVector3 vector1, MyVector3 vector2)
        {
            return AddVector3(vector1, vector2);
        }
        public static MyVector3 operator -(MyVector3 vector1, MyVector3 vector2)
        {
            return SubtractVector3(vector1, vector2);
        }
        public static MyVector3 operator *(MyVector3 vector1, float scalar)
        {
            return MultiplyVector3(vector1, scalar);
        }
        public static MyVector3 operator *(MyVector3 vector1, MyVector3 scalar)
        {
            return MultiplyVector3(vector1, scalar);
        }

        public static MyVector3 operator /(MyVector3 vector1, float divisor)
        {
            return MultiplyVector3(vector1, divisor);
        }
    }
    
    public class MyVector4
    {
        public float x, y, z, w = 0f;
        public MyVector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }
        public MyVector4(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        public static MyVector3 ConverToVector3(MyVector4 vector)
        {
            return new MyVector3(vector.x,vector.y,vector.z);
        }
       
    }


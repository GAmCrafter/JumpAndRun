using UnityEngine;
using Unity.Collections;
using JetBrains.Annotations;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;

//custom namespace to be used in other scripts
namespace extensions
{
    public static class Utility
    {
        //change a vectors x-Value
        public static Vector3 WithX(this Vector3 vector, float newX)
        {
            //returns input vector with new x-Value
            return new Vector3(newX, vector.y, vector.z);
        }

        //change a vectors y-Value
        public static Vector3 WithY(this Vector3 vector, float newY)
        {
            //returns input vector with new y-Value
            return new Vector3(vector.x, newY, vector.z);
        }

        //change a vectors z-Value
        public static Vector3 WithZ(this Vector3 vector, float newZ)
        {
            //returns input vector with new z-Value
            return new Vector3(vector.x, vector.y, newZ);
        }

        //destroy every childObject related to input transform
        public static void DestroyChildren(this Transform transform)
        {
            //iterates over every child contained in input
            foreach (Transform child in transform)
            {
                //destroys selected child
                GameObject.Destroy(child.gameObject);
            }
        }
        
        //set every local value of a transform to standard
        public static void resetLocal(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = new Quaternion(0, 0, 0, 1);
            transform.localScale = new Vector3(1, 1, 1);
        }

        //make a gameObject face a target
        public static void lookAt2D(this Transform transform, Transform target, float angleOffset = 0f, float minAngle = -180f, float maxAngle = 180f)
        {
            //get vector difference between target and self
            Vector3 dir = target.position - transform.position;

            // converts difference from vector to angle, then applies the offset
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;

            //clamp relative to the middle of the range so ranges that cross 180°/-180° still work
            float mid = (minAngle + maxAngle) / 2f;
            float half = (maxAngle - minAngle) / 2f;
            float delta = Mathf.DeltaAngle(mid, angle);
            angle = mid + Mathf.Clamp(delta, -half, half);

            //keep the current x and y rotation, only change z
            Vector3 euler = transform.eulerAngles;
            euler.z = angle;
            transform.eulerAngles = euler;
        }
        

        //return input color with new transparency-value
        public static Color withAlpha(this Color color, float newA)
        {
            //keep RGB values and only change alpha
            return new Color(color.r, color.g, color.b, newA);
        }

        //select a random Element from a list
        public static T RandomElement<T>(this IList list)
        {
            //select a random index in range 0, length of list; saves it in an int
            int index = Random.Range(0, list.Count);

            //returns item corresponding to that index after typecasting it to indicated type
            return (T)list[index];
        }

        //shuffles list using fisher-yates algorhytm
        public static IList shuffleList<T>(this IList Inlist)
        {
            // create new empty list
            List<T> outList = new List<T>();
            //fisher-yates algorhythm
            //selects random element, adds it to outList and removes it from input List
            while (Inlist.Count > 0)
            {
                T rand = Inlist.RandomElement<T>();
                outList.Add(rand);
                Inlist.Remove(rand);
            }
            //returns shuffled list
            return outList;
        }

        //prints every item in a list
        public static void printList<T>(this IList list)
        {
            //iterates over list and prints item as string
            foreach (var x in list) Debug.Log(x.ToString());
        }
    }
}


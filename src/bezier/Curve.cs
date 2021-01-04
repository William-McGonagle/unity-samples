using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve
{

    public Vector3[] points;
    public float length {
        get {

            return points.Length - 1;

        }
    }
    public float distance
    {
        get {

            float dist = 0;

            for (int i = 0; i < points.Length - 1; i++)
            {

                dist += Vector3.Distance(points[i], points[i + 1]);

            }

            return dist;

        }
    }

    public Vector3 LerpSample(float a)
    {

        throw new System.NotImplementedException();

    }

    public Vector3 BezierSample(float a)
    {

        throw new System.NotImplementedException(); 

    }

}

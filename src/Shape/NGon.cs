using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGon
{

    public static float Area(int n, float radius)
    {

        // Standard Forumula for Area of N-Gon
        return (n * radius * radius) / (4 * Mathf.Tan(Mathf.PI / n));

    }

    public static float Area(int n, float width, float height)
    {

        // Initialize Values
        float radius = 0;
        float angleMeasure = Mathf.PI / n;

        // Check if N is Odd
        if (n % 2 == 0)
        {

            // Formula for Radius Given Height for Even N
            radius = height * Mathf.Tan(angle);

        }
        else
        {

            // Formula for Radius Given Height for Odd N
            radius = (2 * height * Mathf.Tan(angleMeasure) * Mathf.Sin(angleMeasure)) / (Mathf.Tan(angleMeasure) + Mathf.Sin(angleMeasure));

        }

        // Return the Area times Width and Height
        return Area(n, radius) * width * height;

    }

    public static Mesh Generate(int n)
    {

        return Generate(1, 1, 1);

    }

    public static Mesh Generate(int n, float size)
    {



    }

    public static Mesh Generate(int n, float width, float height)
    {



    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGon
{

    private static float RadiusFromHeight(float height)
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

        return radius;

    }

    public static float Area(int n, float radius)
    {

        // Standard Forumula for Area of N-Gon
        return (n * radius * radius) / (4 * Mathf.Tan(Mathf.PI / n));

    }

    public static float Area(int n, float width, float height)
    {

        // Convert Height to Radius
        float radius = RadiusFromHeight(height);

        // Return the Area times Width and Height
        return Area(n, radius) * width * height;

    }

    public static Mesh Generate(int n)
    {

        // Return the Generated Mesh
        return Generate(n, 1, 1);

    }

    public static Mesh Generate(int n, float radius)
    {

        // Initialize Variables
        float pointAngle = Mathf.PI / n;
        Vector3[] vertices = new Vector3[n + 1];
        int[] indicies = new int[n * 3];

        // Middle Point
        vertices[0] = new Vector3(0, 0, 0);

        // Loop Through Border Points
        for (int i = 0; i < n; i++)
        {

            // Add Vertices at Border Point
            vertices[i + 1] = new Vector3(Mathf.Cos(n * i), Mathf.Sin(n * i), 0);

            // Add Triangle to Connect
            indicies[(3 * i) + 0] = 0;
            indicies[(3 * i) + 1] = (i + 1);
            indicies[(3 * i) + 2] = ((i + 1) % n) + 1;

        }

        // Create Mesh Object
        Mesh output = new Mesh();

        // Set Mesh Object Data
        output.vertices = vertices;
        output.triangles = indicies;

        // Optimize Mesh
        output.Optimize();

        // Clean Up Mesh
        output.RecalculateTangents();
        output.RecalculateNormals();
        output.RecalculateBounds();

        // Output the Cleaned Mesh
        return output;

    }

    public static Mesh Generate(int n, float width, float height)
    {

        // TODO: STRETCH THE MESH TO COVER WIDTH AND HEIGHT

        // Convert Height to Radius
        float radius = RadiusFromHeight(n, height);

        // Return the Generated Mesh
        return Generate(n, radius);

    }

}

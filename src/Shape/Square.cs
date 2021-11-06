using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{

    /// <summary>
    /// Gets the Area of a Square with a variable size.
    /// </summary>
    /// <param name="size">The size of the Rectangular Prism.</param>
    /// <returns>Area of the Square as a float.</returns>
    public static float Area(float size)
    {

        return size * size;

    }

    /// <summary>
    /// Gets the Area of a Square given its width and height. (WxH)
    /// </summary>
    /// <param name="width">Width of the Square. (X Axis)</param>
    /// <param name="height">Height of the Square. (Y Axis)</param>
    /// <returns>Area of the Square as a float.</returns>
    public static float Area(float width, float height)
    {

        return width * height;

    }

    /// <summary>
    /// Generates a Square with a size of 1. (1x1)
    /// </summary>
    /// <returns>The mesh of the Square.</returns>
    public static Mesh Generate()
    {

        return Generate(1, 1, 1);

    }

    /// <summary>
    /// Generates the Mesh for a Square with a variable Size. (NxN)
    /// </summary>
    /// <param name="size">The size of the Square.</param>
    /// <returns>The mesh of the Square.</returns>
    public static Mesh Generate(float size)
    {

        return Generate(size, size);

    }

    /// <summary>
    /// Generates the Mesh for a Square given a width and height. (WxH)
    /// </summary>
    /// <param name="width">Width of the Square. (X Axis)</param>
    /// <param name="height">Height of the Square. (Y Axis)</param>
    /// <returns>The mesh of the Square.</returns>
    public static Mesh Generate(float width, float height)
    {

        // Create the Vertices Array
        Vector3[] vertices = {
            new Vector3(-width / 2, -height / 2, 0),
            new Vector3( width / 2, -height / 2, 0),
            new Vector3( width / 2,  height / 2, 0),
            new Vector3(-width / 2,  height / 2, 0)
        };

        // Create the Triangles Array
        int[] triangles = {
            0, 2, 1,
            0, 3, 2,
        };

        // Create Mesh Object
        Mesh output = new Mesh();

        // Set Mesh Object Data
        output.vertices = vertices;
        output.triangles = triangles;

        // Optimize Mesh
        output.Optimize();

        // Clean Up Mesh
        output.RecalculateTangents();
        output.RecalculateNormals();
        output.RecalculateBounds();

        // Output the Cleaned Mesh
        return output;

    }

}

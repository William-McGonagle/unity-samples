using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangularPrism
{

    /// <summary>
    /// Generates a Rectangular Prism with a size of 1. (1x1x1)
    /// </summary>
    /// <returns>The mesh of a Rectangular Prism.</returns>
    public static Mesh Generate() {

        return Generate(1, 1, 1);
    
    }

    /// <summary>
    /// Generate a Rectangular Prism with a variable size. (NxNxN)
    /// </summary>
    /// <param name="size">The size of the Rectangular Prism.</param>
    /// <returns>The mesh of a Rectangular Prism.</returns>
    public static Mesh Generate(float size) {

        return Generate(size, size, size);
    
    }

    /// <summary>
    /// Generate the Mesh for a Rectangular Prism given a width, height, and depth. (WxHxD)
    /// </summary>
    /// <param name="width">Width of the Rectangular Prism. (X Axis)</param>
    /// <param name="height">Height of the Rectangular Prism. (Y Axis)</param>
    /// <param name="depth">Depth of the Rectangular Prism. (Z Axis)</param>
    /// <returns>The mesh of a Rectangular Rrism.</returns>
    public static Mesh Generate(float width, float height, float depth) {

        // Create the Vertices Array
        Vector3[] vertices = {
            new Vector3(-width / 2, -height / 2, -depth / 2),
            new Vector3( width / 2, -height / 2, -depth / 2),
            new Vector3( width / 2,  height / 2, -depth / 2),
            new Vector3(-width / 2,  height / 2, -depth / 2),
            new Vector3(-width / 2,  height / 2,  depth / 2),
            new Vector3( width / 2,  height / 2,  depth / 2),
            new Vector3( width / 2, -height / 2,  depth / 2),
            new Vector3(-width / 2, -height / 2,  depth / 2),
        };

        // Create the Triangles Array
        int[] triangles = {
            0, 2, 1,
	        0, 3, 2,
            2, 3, 4,
	        2, 4, 5,
            1, 2, 5,
	        1, 5, 6,
            0, 7, 4,
	        0, 4, 3,
            5, 4, 7,
	        5, 7, 6,
            0, 6, 7,
	        0, 1, 6,
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

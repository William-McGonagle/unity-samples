using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangularPrism
{

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

        // Clean Up Mesh
        output.RecalculateTangents();
        output.RecalculateNormals();
        output.RecalculateBounds();

        // Output the Cleaned Mesh
        return output;
    
    }

}

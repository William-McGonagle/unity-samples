using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk
{

    // Chunk Sizes
    public static int chunkWidth = 128;
    public static int chunkHeight = 128;

    // Chunk Data
    public float[,] chunkData;

    /// <summary>
    /// Get the height of the terrain at a specific point. 
    /// </summary>
    /// <param name="xPos">The x-position of the terrain that you are trying to sample.</param>
    /// <param name="yPos">The y-position of the terrain that you are trying to sample.</param>
    /// <returns>The height of the terrain specified by the point in the parameters.</returns>
    public float GetTerrainHeight(float xPos, float yPos)
    {

        // Find the Lowest Point that can be Rounded to
        int xRealPos = (int)Mathf.Floor(xPos);
        int yRealPos = (int)Mathf.Floor(yPos);

        // Get the Four Terrain Heights
        float x0y0 = chunkData[xRealPos + 0, yRealPos + 0];
        float x1y0 = chunkData[xRealPos + 0, yRealPos + 0];
        float x0y1 = chunkData[xRealPos + 0, yRealPos + 0];
        float x1y1 = chunkData[xRealPos + 0, yRealPos + 0];

        // Get the Percentage of Where the Point lies Realtive to the Grid Points
        float interpAmountX = Mathf.InverseLerp(xRealPos, xRealPos + 1, xPos);
        float interpAmountY = Mathf.InverseLerp(yRealPos, yRealPos + 1, yPos);

        // Interpolate on the X-Axis
        float xInterp0 = Mathf.Lerp(interpAmountX, x0y0, x1y0);
        float xInterp1 = Mathf.Lerp(interpAmountX, x0y1, x1y1);

        // Return the Fully Interpolated Output
        return Mathf.Lerp(interpAmountY, xInterp0, xInterp1);

    }

    /// <summary>
    /// Get the slope between two points on the terrain. 
    /// </summary>
    /// <param name="xPos0">The x-position of the first point on the terrain.</param>
    /// <param name="yPos0">The y-position of the first point on the terrain.</param>
    /// <param name="xPos1">The x-position of the second point on the terrain.</param>
    /// <param name="yPos1">The y-position of the second point on the terrain.</param>
    /// <returns>The slope between the two points provided in the parameters.</returns>
    public float GetTerrainSlope(float xPos0, float yPos0, float xPos1, float yPos1) {

        // Get the Two Heights
        float height0 = GetTerrainHeight(xPos0, yPos0);
        float height1 = GetTerrainHeight(xPos1, yPos1);

        // Get the Height Difference and Position Difference
        float heightDelta = height0 - height1;
        float posDelta = Vector2.Distance(new Vector2(xPos0, yPos0), new Vector2(xPos1, yPos1));

        // Slope is Rise over Run
        return heightDelta / posDelta;

    }

    /// <summary>
    /// Set the height of a point on the terrain in a hard manner. The height data will NOT be equally distributed among the surrounding points- creating rough edges.
    /// </summary>
    /// <param name="xPos">The x-position of the point where the height needs to be set.</param>
    /// <param name="yPos">The y-position of the point where the height needs to be set.</param>
    /// <param name="height">The height of the terrain at the point.</param>
    public void ForcefullySetTerrainHeight(float xPos, float yPos, float height) { 
    
        // Round to the Closest Grid
        int xRealPos = (int)xPos;
        int yRealPos = (int)yPos;

        // Set the Height at the Proper Grid Position
        chunkData[xRealPos, yRealPos] = height;

    }

    /// <summary>
    /// Set the height of a point on the terrain in a soft manner. The height data will be equally distributed among the surrounding points- stopping rough edges.
    /// </summary>
    /// <param name="xPos">The x-position of the point where the height needs to be set.</param>
    /// <param name="yPos">The y-position of the point where the height needs to be set.</param>
    /// <param name="height">The height of the terrain at the point.</param>
    public void SoftlySetTerrainHeight(float xPos, float yPos, float height) {

        throw new System.NotImplementedException("This function has not yet been built- please use the ForcefullySetTerrainHeight function instead.");
    
    }

    /// <summary>
    /// Generate the Unity Mesh Data for the terrain chunk.
    /// </summary>
    /// <returns>A Unity Mesh from the terrain data.</returns>
    public Mesh GenerateTerrainMesh() {

        return GenerateTerrainMesh(1);
    
    }

    /// <summary>
    /// Generate the Unity Mesh Data for the terrain chunk with control over resolution.
    /// </summary>
    /// <param name="division">The division factor on the terrain. Ex: 2 will divide the Terrain's resolution by 2.</param>
    /// <returns>A Unity Mesh from the terrain data.</returns>
    public Mesh GenerateTerrainMesh(int division) {

        // Generate Vertices Array
        Vector3[] vertices = new Vector3[((chunkWidth / division) + 1) * ((chunkHeight / division) + 1)];
        Vector2[] uvs = new Vector2[vertices.Length];

        // Iterate Through the Grid Points
        int i = 0;
        for (int x = 0; x <= chunkWidth / division; x++)
        {

            for (int y = 0; y <= chunkHeight / division; y++)
            {

                // Set the Vertices and UVS Equal to their Positions
                uvs[i] = new Vector2((float)(x / (chunkWidth / division)), (float)(y / (chunkHeight / division)));
                vertices[i] = new Vector3(x * division, GetTerrainHeight(x * division, y * division), y * division);
                i++;

            }

        }

        // Initialize Triangles/ Indices Array
        int[] triangles = new int[(chunkWidth / division) * (chunkHeight / division) * 6];

        // Iterate Through the Grid Points
        int vert = 0;
        int tris = 0;
        for (int y = 0; y < chunkHeight / division; y++)
        {

            for (int x = 0; x < chunkWidth / division; x++)
            {

                // Create Two Triangles
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + (chunkWidth / division) + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + (chunkWidth / division) + 1;
                triangles[tris + 5] = vert + (chunkWidth / division) + 2;

                // Iterate the Other Variables
                vert++;
                tris += 6;

            }

            // Prevent Back Faces Generated at Bottom
            vert++;

        }
        
        // Create a new Unity Mesh
        Mesh output = new Mesh();

        // Set the Mesh data to the values that were generated
        output.vertices = vertices;
        output.triangles = triangles;
        output.uv = uvs;

        // Run Functions to Clean up the Mesh
        output.RecalculateTangents();
        output.RecalculateNormals();
        output.RecalculateBounds();

        // Return the Generated Mesh
        return output;

    }
    
}

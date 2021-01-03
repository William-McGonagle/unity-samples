using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk
{

    // Chunk Sizes
    public static int width = 128;
    public static int height = 128;

    // Chunk Data
    public float[,] chunkData;

    /// <summary>
    /// Get the height of the terrain at a specific point. 
    /// </summary>
    /// <param name="xPos">The x-position of the terrain that you are trying to sample.</param>
    /// <param name="yPos">The y-position of the terrain that you are trying to sample.</param>
    /// <returns></returns>
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
    
}

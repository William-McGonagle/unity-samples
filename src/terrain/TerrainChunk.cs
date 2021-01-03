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
    
}

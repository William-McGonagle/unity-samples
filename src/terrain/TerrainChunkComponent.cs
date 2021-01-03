using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TerrainChunkComponent : MonoBehaviour
{

    [HideInInspector]
    public TerrainChunk chunk;
    [HideInInspector]
    public MeshFilter filt;

    void Start()
    {

        chunk = new TerrainChunk();
        filt = GetComponent<MeshFilter>();
        filt.mesh = chunk.GenerateTerrainMesh();

    }

}

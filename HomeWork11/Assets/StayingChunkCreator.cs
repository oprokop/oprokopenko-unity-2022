using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayingChunkCreator : MonoBehaviour
{
    public Material material;
    int chunkIndex = -1;
    List<GameObject> chunks = new List<GameObject>();

    public void Create(float baseX, Vector3 objectPosition, Mesh objectMesh)
    {
        chunkIndex++;
        GameObject stayingChunk = new GameObject($"StayingChunk{chunkIndex}", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider));
        chunks.Add(stayingChunk);
        Mesh otherMesh;
        MeshCollider otherMeshCollider;
        otherMesh = chunks[chunkIndex].GetComponent<MeshFilter>().mesh;
        otherMesh.vertices = objectMesh.vertices;
        otherMesh.triangles = objectMesh.triangles;
        otherMesh.RecalculateNormals();
        otherMeshCollider = chunks[chunkIndex].GetComponent<MeshCollider>();
        otherMeshCollider.convex = true;
        otherMeshCollider.sharedMesh = otherMesh;
        chunks[chunkIndex].GetComponent<MeshRenderer>().material = material;
        chunks[chunkIndex].GetComponent<Transform>().position = new Vector3(baseX, objectPosition.y, objectPosition.z);
    }
}

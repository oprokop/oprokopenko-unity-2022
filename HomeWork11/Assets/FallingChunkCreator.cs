using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingChunkCreator : MonoBehaviour
{
    public CubeGenerator generator;
    public Material material;
    int chunkIndex = -1;
    List<GameObject> chunks = new List<GameObject>();

    public void Create(Vector3 objectPosition, float offset)
    {
        chunkIndex++;
        GameObject fallingChunk = new GameObject($"FallingChunk{chunkIndex}", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider), typeof(Rigidbody));
        chunks.Add(fallingChunk);
        Mesh otherMesh;
        MeshCollider otherMeshCollider;
        otherMesh = chunks[chunkIndex].GetComponent<MeshFilter>().mesh;
        otherMesh.vertices = generator.GenerateVertices(-offset / 2.0f, offset / 2.0f);
        otherMesh.triangles = generator.GenerateTriangles();
        otherMesh.RecalculateNormals();
        otherMeshCollider = chunks[chunkIndex].GetComponent<MeshCollider>();
        otherMeshCollider.convex = true;
        otherMeshCollider.sharedMesh = otherMesh;
        chunks[chunkIndex].GetComponent<MeshRenderer>().material = material;
        chunks[chunkIndex].GetComponent<Transform>().position = objectPosition;
    }
}

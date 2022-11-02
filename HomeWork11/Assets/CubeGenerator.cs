using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public Vector3[] GenerateVertices(float x1, float x2)
    {
        return new Vector3[]
        {
            new Vector3(x1, -1.0f, -5.0f),
            new Vector3(x2, -1.0f, -5.0f),
            new Vector3(x2, -1.0f, 5.0f),
            new Vector3(x1, -1.0f, 5.0f),
            new Vector3(x1, 1.0f, -5.0f),
            new Vector3(x2, 1.0f, -5.0f),
            new Vector3(x2, 1.0f, 5.0f),
            new Vector3(x1, 1.0f, 5.0f),
        };
    }

    public int[] GenerateTriangles()
    {
        return new int[] 
        { 
            0,2,1, 0,3,2, 
            4,5,6, 4,6,7,
            0,1,4, 4,1,5,
            1,2,5, 5,2,6,
            2,3,6, 3,7,6,
            0,4,3, 4,7,3
        };
    }
}


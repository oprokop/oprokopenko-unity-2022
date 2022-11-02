using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject mainObject;
    public CubeGenerator generator;
    public Movement movement;
    public Material material;
    private float offset;
    private float baseX;
    private Vector3 fallingChunkPosition;
    private readonly float edgeXPoint = -38.0f;
    private const float height = 2.0f;
    public StayingChunkCreator chunkCreator;
    public FallingChunkCreator fallingChunkCreator;
    
    public int level;
    public TMP_Text levelText;
    Touch touch;

    private float x1;
    private float x2;
    Vector3 startPos;
    Mesh mesh;

    void Start()
    {
        baseX = -20.0f;
        offset = 0.0f;
        x1 = 5.0f;
        x2 = -5.0f;

        mesh = new Mesh();

        mainObject.GetComponent<MeshRenderer>().material = material;
        mainObject.GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = generator.GenerateVertices(x1, x2);
        mesh.triangles = generator.GenerateTriangles();
        mesh.RecalculateNormals();

        startPos = mainObject.transform.position;
    }
    void Update()
    {
        movement.Move();
        if(mainObject.transform.position.x < edgeXPoint)
        {
            mainObject.transform.position = startPos;
        }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                var delta = Math.Abs(mainObject.transform.position.x - baseX) / 2;

                if (mainObject.transform.position.x > baseX && delta < x1)
                {
                    offset = baseX - mainObject.transform.position.x;
                    baseX = baseX - offset / 2;
                }
                else if (mainObject.transform.position.x < baseX && delta < x1)
                {
                    offset = mainObject.transform.position.x - baseX;
                    baseX = baseX + offset / 2;
                }
                else
                {
                    return;
                }

                x1 += offset / 2;
                x2 -= offset / 2;

                mesh.vertices = generator.GenerateVertices(x1, x2);
                mesh.triangles = generator.GenerateTriangles();
                mesh.RecalculateNormals();

                chunkCreator.Create(baseX, mainObject.transform.position, mesh);

                if (mainObject.transform.position.x > baseX)
                {
                    fallingChunkPosition = new Vector3(baseX + x1 - offset / 2, mainObject.transform.position.y, mainObject.transform.position.z);
                }
                else if (mainObject.transform.position.x < baseX)
                {
                    fallingChunkPosition = new Vector3(baseX - x1 + offset / 2, mainObject.transform.position.y, mainObject.transform.position.z);
                }

                fallingChunkCreator.Create(fallingChunkPosition, offset);

                startPos = new Vector3(startPos.x, startPos.y + height, startPos.z);

                if (startPos.y > mainObject.transform.position.y)
                {
                    level++;
                    levelText.text = $"Level: {level}";
                }

                mainObject.transform.position = startPos;
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + height, mainCamera.transform.position.z);
                movement.SpeedUp();
            }
        
        }
    }
} 

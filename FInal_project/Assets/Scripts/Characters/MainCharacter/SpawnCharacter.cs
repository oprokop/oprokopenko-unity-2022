using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Vector3 spawnPos;
    [SerializeField] Camera mainCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hi");
            SpawnObject(prefab, spawnPos, mainCamera);
        }
    }
    public void SpawnObject(GameObject prefab, Vector3 spawnPos, Camera mainCamera)
    {
        var player = Instantiate(prefab, spawnPos, Quaternion.identity);
        mainCamera.transform.parent = player.transform;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
      
    }
    
    void Update()
    {
        if(prefab == null)
        {
            Debug.LogError("Prefab is NULL!!!");
            return;
        }

        transform.RotateAround(prefab.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
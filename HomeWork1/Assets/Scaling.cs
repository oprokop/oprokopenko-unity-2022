using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
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

        var sizeConstraint = new Vector3(10,10,10);
        var sizeIncreasing = new Vector3(1,1,1);

        if(prefab.transform.localScale != sizeConstraint)
        {
            prefab.transform.localScale = prefab.transform.localScale + sizeIncreasing;
        }
       
    }
}
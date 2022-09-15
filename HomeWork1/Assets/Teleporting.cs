using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public GameObject prefab;

    public float timeWork = 5f;

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

        timeWork -= Time.deltaTime; 
        
        if (timeWork <= 0)
        {
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);
            float z = Random.Range(-5.0f, 5.0f);
            var disp = new Vector3(x, y, z);
            transform.Translate(disp);
            timeWork = 5f;
        }           
    }
}



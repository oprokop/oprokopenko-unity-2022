using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    private float tpPointY;
    Vector3 tpPos;

    private void Start()
    {
        tpPointY = transform.position.y;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        tpPos = new Vector3(transform.position.x, tpPointY, transform.position.z);
        transform.position = tpPos;
    }
}

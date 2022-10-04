using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunRotation : MonoBehaviour
{
    [SerializeField] SpriteRenderer ninja;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           ninja.flipX = !ninja.flipX;
        }
    }
}

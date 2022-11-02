using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void SpeedUp()
    {
        speed += 0.5f;
    }
}

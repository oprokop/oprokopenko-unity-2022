using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public void Move(Vector2 direction)
    {
        transform.Translate(new Vector3(direction.x, direction.y, 0.0f) * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotController : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed = 10.0f;

    CharacterController controller;

    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    
    void Update()
    {
        Vector3 angles = transform.rotation.eulerAngles;
        float xRotation = (angles.x + 180f) % 360f - 180f;
        xRotation -= Input.GetAxis("Mouse Y") * speed;
        xRotation = Mathf.Clamp(xRotation, -35f, 35f);
        transform.rotation = Quaternion.Euler(new Vector3(xRotation, angles.y, angles.z));
    }
}

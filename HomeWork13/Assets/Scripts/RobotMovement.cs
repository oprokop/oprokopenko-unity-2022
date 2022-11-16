using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;
        if(sideForce != 0.0f)
        {
            rb.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }

        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForce != 0.0f)
        {
            rb.velocity = rb.transform.forward * forwardForce;
        }
    }
}

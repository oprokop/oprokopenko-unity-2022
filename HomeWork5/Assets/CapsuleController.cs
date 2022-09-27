using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed = 10.0f;

    CharacterController controller;

    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float yRotation = Input.GetAxis("Mouse X");
       
        float moveUp = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(horizontal * speed, gravity, vertical * speed);
        Vector3 jump = new Vector3(0.0f, moveUp, 0.0f);

        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        Controller.transform.Rotate(Vector3.up, yRotation);
        Controller.transform.Translate(jump);
    }
}

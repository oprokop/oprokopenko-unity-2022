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
        float rotation = Input.GetAxis("Mouse X");

        Vector3 movement = new Vector3(horizontal * speed, gravity, vertical * speed);
        Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        Controller.transform.Rotate(Vector3.up, rotation);
    }
}
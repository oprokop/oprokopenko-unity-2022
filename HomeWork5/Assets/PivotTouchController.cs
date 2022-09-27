using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotTouchController : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed = 10.0f;

    private float startingPosition;

    CharacterController controller;

    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    void Update()
    {
        
        //Debug.Log(xRotation.ToString());

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startingPosition = touch.position.y;
                    //Debug.Log(touch.position.y);
                    break;

                case TouchPhase.Moved:
                    if (startingPosition > touch.position.y)
                    {
                        Vector3 angles = transform.rotation.eulerAngles;
                        float xRotation = ((angles.x + 180f) % 360f - 180f);
                        xRotation -= touch.position.y * speed;
                        //Debug.Log(xRotation.ToString());
                        xRotation = Mathf.Clamp(xRotation, -20f, 20f);
                        transform.rotation = Quaternion.Euler(new Vector3(xRotation, angles.y, angles.z));
                    }
                    else if (startingPosition < touch.position.y)
                    {
                        Vector3 angles = transform.rotation.eulerAngles;
                        float xRotation = ((angles.x + 180f) % 360f - 180f);
                        xRotation -= touch.position.y * -speed;
                        xRotation = Mathf.Clamp(xRotation, -20f, 20f);
                        transform.rotation = Quaternion.Euler(new Vector3(xRotation, angles.y, angles.z));
                    }
                    break;

                case TouchPhase.Ended:
                    //Debug.Log("Touch Phase Ended.");
                    break;

                case TouchPhase.Stationary:
                    startingPosition = touch.position.y;
                    break;
            }
        }
    }
}

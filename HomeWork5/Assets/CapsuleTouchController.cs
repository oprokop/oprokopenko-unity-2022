using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CapsuleTouchController : MonoBehaviour
{
    public float gravity = -9.81f;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    private float startingPositionX;
    
    public float jumpHeight = 2.0f;

    bool isForwardPressed;
    bool isBackPressed;
    bool isRightPressed;
    bool isLeftPressed;

    CharacterController controller;
    
    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }

    public void onForwardDown()
    {
        isForwardPressed = true;
    }
    public void onForwardUp()
    {
        isForwardPressed = false;
    }
    public void onBackDown()
    {
        isBackPressed = true;
    }
    public void onBackUp()
    {
        isBackPressed = false;
    }
    public void onRightDown()
    {
        isRightPressed = true;
    }
    public void onRightUp()
    {
        isRightPressed = false;
    }
    public void onLeftDown()
    {
        isLeftPressed = true;
    }
    public void onLeftUp()
    {
        isLeftPressed = false;
    }
    void Update()
    {
        Move();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startingPositionX = touch.position.x;
                    break;

                case TouchPhase.Moved:
                    if (startingPositionX > touch.position.x)
                    {
                        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
                    }
                    else if (startingPositionX < touch.position.x)
                    {
                        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                    }
                    break;

                case TouchPhase.Ended:
                    //Debug.Log("Touch Phase Ended.");
                    break;

                case TouchPhase.Stationary:
                    startingPositionX = touch.position.x;
                    break;
            }
        }
    }

    public void Jump()
    {
        Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
        Controller.Move(transform.TransformDirection(jump));
    }

    public void Move()
    {
        if(isForwardPressed)
        {
            Vector3 movement = Vector3.forward * speed;
            Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        }
        else if (isBackPressed)
        {
            Vector3 movement = Vector3.back * speed;
            Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        }
        else if (isRightPressed)
        {
            Vector3 movement = Vector3.right * speed;
            Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        }
        else if (isLeftPressed)
        {
            Vector3 movement = Vector3.left * speed;
            Controller.Move(transform.TransformDirection(movement) * Time.deltaTime);
        }
        else
        {
            Vector3 movement = Vector3.zero;
        }
    }
}


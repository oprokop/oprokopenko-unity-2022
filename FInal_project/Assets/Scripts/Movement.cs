using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(SpriteRenderer))]

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    
    SpriteRenderer spriteRenderer;

    public CharacterController CharacterController { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    //public MoveController controller;
    
    public InputManager input;
    private float axis;
    bool isJumping = false;
    float speedY = 0.0f;
    float gravity = -9.81f;
    float jumpSpeed = 1.4f;
    float speedLimit = 8.0f;
    Vector2 movement;
    float basePositionY;
    private void Awake()
    {
        basePositionY = transform.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
        input.OnRightMoved += OnRightMoved;
        input.OnLeftMoved += OnLeftMoved;
        input.OnMoveStarted += Move;
        input.OnJumpPressed += Jump;
        input.OnNothingPressed += OnNothingPressed;
    }

    private void Update()
    {
        if (isJumping)
        {
            Land();
            Vector2 verticalMovement = Vector2.up * speedY;
            movement += verticalMovement;
        }

        CharacterController.Move(movement * Time.deltaTime);
        
        if (!isJumping)
        {
            var ground = new Vector2(transform.position.x, 0.74f);
            transform.position = ground;
        }
    }

    private void OnNothingPressed()
    {
        axis = 0;
        movement.x = axis;
    }

    private void OnRightMoved()
    {
        axis = 1;
    }

    private void OnLeftMoved()
    {
        axis = -1;
    }

    private void Move()
    {
        spriteRenderer.flipX = axis < 0 ? true : false;
        Vector2 horizontalMovement = new Vector2(axis, 0.0f);
        movement += horizontalMovement;
        if (movement.x > 8.0f)
        {
            movement.x = speedLimit;
        }
        else if (movement.x < -8.0f)
        {
            movement.x = -speedLimit;
        }
    }

    void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            speedY += jumpSpeed;
        }
    }

    void Land()
    {
        if (transform.position.y > basePositionY && isJumping)
        {
            speedY += gravity * Time.deltaTime;
        }
        else if (speedY < 0.0f)
        {
            speedY = 0.0f;
        }
        if (transform.position.y < basePositionY)
        {
            isJumping = false;
            movement.y = 0.0f;
            speedY = 0.0f;
        }
    }

    public float GetSpeed()
    {
        return movement.x;
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    private void OnDestroy()
    {
        if (input)
        {
            input.OnRightMoved -= OnRightMoved;
            input.OnLeftMoved -= OnLeftMoved;
            input.OnMoveStarted -= Move;
            input.OnJumpPressed -= Jump;
            input.OnNothingPressed -= OnNothingPressed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Enemy enemyInstance;
    public float speed;
    private float playerDirection;
    public float jumpForce;
    public GameObject deathScreen;
    public GameObject enemy;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator spriteAnimator;
    private bool isDead = false;
    private bool isGrounded;
    private Vector2 startPos;

    private readonly float fallBorder = -20;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteAnimator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        playerDirection = Input.GetAxis("Horizontal");

        if (transform.position.y < fallBorder && !isDead)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.R) && isDead)
        {
            Resurrection();
        }
    }

    void FixedUpdate()
    {
        if (playerDirection != 0)
        {
            SwitchDir();
            if (isGrounded)
            {
                Startwalking();
            }
        }
        
        if (playerDirection == 0)
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = !isGrounded;
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void SwitchDir()
    {
        spriteRenderer.flipX = playerDirection < 0 ? true : false;
    }

    private void Idle()
    {
        spriteAnimator.SetTrigger("Idle");
    }

    private void Startwalking()
    {
        spriteAnimator.SetTrigger("Run");
        body.velocity = new Vector2(playerDirection, 0) * speed * Time.fixedDeltaTime;
    }

    public void Resurrection()
    {
        isDead = !isDead;
        transform.position = startPos;
        foreach (Transform child in transform)
        {
            if (child.tag == "DeathScreen")
            {
                Destroy(child.gameObject);
            }
        }
        foreach (Transform child in enemy.transform)
        {
            if (child.tag == "CyberTruck")
            {
                Destroy (child.gameObject);
            }
        }
        enemyInstance.isInstantiated = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.collider.tag == "CyberTruck" && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(deathScreen, transform);
        isDead = !isDead;
    }
}

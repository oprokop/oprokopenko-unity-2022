using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMovement : MonoBehaviour
{
    public float parallaxEffect;
    public float parallaxSpeed;
    private float length;
    private float startPos;
    private bool isRightMovement;
    private Transform spritePos;

    void Start()
    {
        isRightMovement = true;
        spritePos = GetComponent<Transform>();
        startPos = spritePos.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRightMovement = !isRightMovement;
        }
       
        if (isRightMovement)
        {
            transform.Translate(-parallaxSpeed * parallaxEffect * Time.deltaTime, 0.0f, 0.0f);
        }
        else
        {
            transform.Translate(parallaxSpeed * parallaxEffect * Time.deltaTime, 0.0f, 0.0f);
        }

        if (transform.position.x >= startPos + length || transform.position.x <= startPos - length)
        {
            transform.position = new Vector3(startPos, transform.position.y);
        }
    }
}


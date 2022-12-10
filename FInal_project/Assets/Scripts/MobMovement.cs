using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class MobMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float maxDistanceToPlayer = 10.0f;
    [SerializeField] float offset = 2.0f;
    SpriteRenderer spriteRenderer;
    //bool isFlip;
    //[SerializeField] LayerMask PlayerMask;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        var currentDistance = Mathf.Abs(transform.position.x - player.transform.position.x);
        if (currentDistance < maxDistanceToPlayer)
        {
            if (transform.position.x > player.transform.position.x + offset)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                spriteRenderer.flipX = false;
            }
            if(transform.position.x < player.transform.position.x - offset)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                spriteRenderer.flipX = true;
            }
        }

        //var hit = Physics2D.OverlapArea(transform.position, Vector2.left);
        //if (hit != null)
        //{
        //    if (hit.CompareTag("Player"))
        //    {
        //        transform.Translate(Vector2.left * speed * Time.deltaTime);
        //    }
        //}
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, maxDistanceToPlayer, PlayerMask);
        //if (hit.collider != null)
        //{
        //    if (hit.collider.CompareTag("Player"))
        //    {
        //        transform.Translate(Vector2.left * speed * Time.deltaTime);
        //    }
        //}
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class MobMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed = 6.0f;
    [SerializeField] float maxDistanceToPlayer = 10.0f;
    [SerializeField] float offset = 2.0f;
    SpriteRenderer spriteRenderer;
    [SerializeField] DamageSystem damageSystem;
    public UnityAction OnMobPunch;
    bool isMoving;
    //bool isFlip;
    //[SerializeField] LayerMask PlayerMask;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageSystem = GetComponent<DamageSystem>();
    }
    void Update()
    {
        var currentDistance = Mathf.Abs(transform.position.x - player.transform.position.x);
        if (currentDistance < maxDistanceToPlayer)
        {
            if (transform.position.x > player.transform.position.x + offset)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                spriteRenderer.flipX = false;
                isMoving = true;
            }
            else if(transform.position.x < player.transform.position.x - offset)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                spriteRenderer.flipX = true;
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        
        else
        {
            isMoving = false;
        }
        if (currentDistance <= offset + 1.0f)
        {
            //damageSystem.MobPunch();
            OnMobPunch?.Invoke();
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}

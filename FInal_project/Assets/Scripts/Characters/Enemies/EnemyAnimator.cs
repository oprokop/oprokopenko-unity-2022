using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Animator))]

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] MobMovement movement;
    [SerializeField] Animator animator;
    [SerializeField] DamageSystem damageSystem;
    bool isDead = false;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    private void Awake()
    {
        damageSystem.OnHurt += Hurt;
        damageSystem.OnFatalHurt += Death;
        movement.OnMobPunch += Punch;
    }

    private void Update()
    {
        if(!isDead)
        {
            Moving();
        }
    }

    void Hurt()
    {
        if (!isDead)
        {
            CharacterAnimator.SetTrigger("Hurt"); ;
        }
    }

    void Moving()
    {
        if (movement.IsMoving() && !isDead)
        {
            CharacterAnimator.SetTrigger("Walk");
        }
    }

    void Punch()
    {
        if(!isDead)
        {
            CharacterAnimator.SetTrigger("Punch");
        }
    }

    void Death()
    {
        isDead = true;
        CharacterAnimator.SetBool("IsDead", true);
    }

    private void OnDestroy()
    {
        damageSystem.OnHurt -= Hurt;
        damageSystem.OnFatalHurt -= Death;
        movement.OnMobPunch -= Punch;
    }
}

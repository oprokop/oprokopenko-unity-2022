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
    bool isDied = false;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    private void Awake()
    {
        damageSystem.OnHurt += Hurt;
        damageSystem.OnFatalHurt += Death;
        movement.OnMobPunch += Punch;
    }

    private void Update()
    {
        if(!isDied)
        {
            Moving();
        }
    }

    void Hurt()
    {
        if (!isDied)
        {
            CharacterAnimator.SetTrigger("Hurt"); ;
        }
    }

    void Moving()
    {
        if (movement.IsMoving() && !isDied)
        {
            CharacterAnimator.SetTrigger("Walk");
        }
    }

    void Punch()
    {
        if(!isDied)
        {
            CharacterAnimator.SetTrigger("Punch");
        }
    }

    void Death()
    {
        isDied = true;
        CharacterAnimator.SetBool("IsDead", true);
    }

    private void OnDestroy()
    {
        damageSystem.OnHurt -= Hurt;
        damageSystem.OnFatalHurt -= Death;
        movement.OnMobPunch -= Punch;
    }
}

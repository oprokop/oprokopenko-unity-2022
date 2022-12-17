using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]

public class CharactAnimator : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] Animator animator;
    [SerializeField] InputManager input;
    [SerializeField] DamageSystem damageSystem;
    [SerializeField] int attackAnimationCount;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    private void Awake()
    {
        input.OnPunch += HandAttack;
        input.OnKick += LegAttack;
        damageSystem.OnHurt += Hurt;
    }

    private void Update()
    {
        Move(movement.GetSpeed());
        Jump(movement.IsJumping());
    }

    void Move(float speed)
    {
        if (speed != 0.0f)
        {
            CharacterAnimator.SetFloat("SpeedX", MathF.Abs(speed));
        }
        else
        {
            CharacterAnimator.SetFloat("SpeedX", 0.0f);
        }
    }

    void Jump(bool isJumping)
    {
        CharacterAnimator.SetBool("IsJumping", isJumping);
    }

    void Hurt()
    {
        CharacterAnimator.SetTrigger("Hurt");
    }

    void HandAttack()
    {
        CharacterAnimator.SetTrigger("HandAttack");
        int currentAttackNumber = Random.Range(0, attackAnimationCount);
        CharacterAnimator.SetInteger("AttackNumber", currentAttackNumber);
    }

    void LegAttack()
    {
        CharacterAnimator.SetTrigger("LegAttack");
        int currentAttackNumber = Random.Range(0, attackAnimationCount + 1);
        CharacterAnimator.SetInteger("AttackNumber", currentAttackNumber);
    }
}

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
    [SerializeField] DamageSystem damageSystem;
    [SerializeField] int handAttackAnimationCount;
    [SerializeField] int legAttackAnimationCount;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    void Awake()
    {
        InputManager.Instance.OnPunch += HandAttack;
        InputManager.Instance.OnKick += LegAttack;
        damageSystem.OnHurt += Hurt;
    }

    void Update()
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
        int currentAttackNumber = Random.Range(0, handAttackAnimationCount);
        CharacterAnimator.SetInteger("AttackNumber", currentAttackNumber);
        CharacterAnimator.SetTrigger("HandAttack");
    }

    void LegAttack()
    {
        CharacterAnimator.SetTrigger("LegAttack");
        int currentAttackNumber = Random.Range(0, legAttackAnimationCount);
        CharacterAnimator.SetInteger("AttackNumber", currentAttackNumber);
    }

    //void OnDestroy()
    //{
    //    if (InputManager.IsValid)
    //    {
    //        InputManager.Instance.OnPunch -= HandAttack;
    //        InputManager.Instance.OnKick -= LegAttack;
    //    }
    //}
}

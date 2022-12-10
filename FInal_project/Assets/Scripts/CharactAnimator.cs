using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharactAnimator : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] Animator animator;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    void MoveAnimation(float speed)
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

    void JumpAnimation(bool isJumping)
    {
        CharacterAnimator.SetBool("IsJumping", isJumping);
    }

    private void Update()
    {
        MoveAnimation(movement.GetSpeed());
        JumpAnimation(movement.IsJumping());
    }

}

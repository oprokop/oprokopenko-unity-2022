using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public abstract class Character : MonoBehaviour
{
    CharacterController controller;
    Animator animator;

    public CharacterController CharacterController { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }
    
    public abstract void Move(Vector3 direction);

    public abstract void Jump();

    public abstract void CauseDamage();

    public abstract void TakeDamage();

}

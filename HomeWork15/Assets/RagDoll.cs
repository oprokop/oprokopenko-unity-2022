using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    public List<Rigidbody> elements;

    public void Dead()
    {
        foreach (var element in elements)
        {
            element.isKinematic = false;
        }
        GetComponent<Animator>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
    }
}

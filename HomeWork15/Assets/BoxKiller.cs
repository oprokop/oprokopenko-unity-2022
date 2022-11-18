using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKiller : MonoBehaviour
{
    [SerializeField] RagDoll rag;
    [SerializeField] Character character;
    [SerializeField] List<Collider> characterColliders;    
    public void OnCollisionEnter(Collision collision)
    {
        foreach(var col in characterColliders)
        {
            if (collision.collider == col)
            {
                rag.Dead();
                character.isDead = true;
            }
        }
    }
}

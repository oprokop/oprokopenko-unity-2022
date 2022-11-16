using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float velocity;
    public PhysicMaterial material;
    
    protected virtual void Awake()
    {
        GetComponent<Collider>().material = material;
    }

    public virtual void Fire()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * velocity, ForceMode.Impulse);
    }
   
}

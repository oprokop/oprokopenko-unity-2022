using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : Projectile
{

    private void OnCollisionEnter(Collision collision)
    {
        var particle = GetComponent<ParticleSystem>();
        particle.Play();
        Destroy(gameObject, particle.main.duration);
    }
}

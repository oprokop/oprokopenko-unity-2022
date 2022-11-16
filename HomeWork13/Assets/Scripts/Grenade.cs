using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Grenade : Projectile
{
    public Material invisibleMaterial;

    public float radius = 20.0F;
    public float power = 20.0F;

    protected override void Awake()
    {
        base.Awake();
    }
    public override void Fire()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, -20) * velocity, ForceMode.Acceleration);// check how direction works
    }

    private void OnCollisionEnter(Collision other)
    {
        var particle = GetComponent<ParticleSystem>();
        var meshRender = GetComponent<MeshRenderer>();
        particle.Play();
        var delay = particle.main.duration;
        Destroy(particle, delay);
        Destroy(gameObject, delay);
        meshRender.material = invisibleMaterial;
        
        Vector3 explosionPos = other.contacts[0].point;
        var colliders = Physics.OverlapSphere(explosionPos, radius);
        
        foreach (Collider hit in colliders)
        {
            if (hit != null)
            {
                var rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 10.0F);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileChanger : MonoBehaviour
{
    [SerializeField] private List<Projectile> projectiles;
    [SerializeField] private List<Collider> planes;
    [SerializeField] private Projectile currentProjectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Projectile current = Instantiate(currentProjectile, new Vector3 (transform.position.x, transform.position.y + 2.0f, transform.position.z), transform.rotation);
            current.Fire();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < planes.Count; i++)
        {
            if (planes[i] == other)
            {
                currentProjectile = projectiles[i];
            }
        }
    }
}

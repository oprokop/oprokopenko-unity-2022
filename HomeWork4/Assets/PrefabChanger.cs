using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabChanger : MonoBehaviour
{
    public GameObject bulletCreator;
    public GameObject grenadePlane;
    public GameObject grenadePrefab;
    public GameObject bulletPrefab;

    private void OnTriggerEnter(Collider other)
    {
        var collideGranadePlane = grenadePlane.GetComponent<Collider>();
        var bulletCreatorProperty = bulletCreator.GetComponent<BulletCreator>();

        if (collideGranadePlane == other && bulletCreatorProperty.prefab != grenadePrefab)
        {
            bulletCreatorProperty.prefab = grenadePrefab;
        }
        else if (bulletCreatorProperty.prefab != bulletPrefab)
        {
            bulletCreatorProperty.prefab = bulletPrefab;
        }
    }
}

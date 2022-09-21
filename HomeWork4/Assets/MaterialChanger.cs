using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public PhysicMaterial PhysicMaterial;
    public GameObject Prefab;

    private void OnTriggerEnter(Collider other)
    {
        var sphereCollider = Prefab.GetComponent<SphereCollider>();
        Debug.Log("onTriggerEnter - " + other);
        sphereCollider.material = PhysicMaterial;
    }
}

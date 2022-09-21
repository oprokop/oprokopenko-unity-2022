using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public GameObject prefab;
    public float velocity;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(prefab, transform.position, transform.rotation);
            //newBullet.GetComponent<Rigidbody>().AddForce(Vector3.back * velocity, ForceMode.Impulse);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * velocity;
        }
    }
}

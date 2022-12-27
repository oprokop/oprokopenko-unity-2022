using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float offsetForward;
    [SerializeField] float offsetBehind;
    [SerializeField] float offsetHeightForBoss;
    bool isTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            SpawnMob();
        }
    }

    void SpawnMob()
    {   
        if(!isTriggered)
        {
            if (offsetBehind == 0)
            {
                var mob = Instantiate(enemy, new Vector3(transform.position.x + offsetForward, transform.position.y + offsetHeightForBoss, transform.position.z), Quaternion.identity);
            }
            else if (offsetBehind > 0)
            {
                var frontMob = Instantiate(enemy, new Vector3(transform.position.x + offsetForward, transform.position.y, transform.position.z), Quaternion.identity);
                var backwardMob = Instantiate(enemy, new Vector3(transform.position.x - offsetBehind, transform.position.y, transform.position.z), Quaternion.identity);
            }
            isTriggered = true;
            audioSource.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioSource wooSource;
    public UnityAction onEnd;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            wooSource.Play();
            onEnd?.Invoke();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource pioneer;
    [SerializeField] DamageSystem damageSystem;

    void Start()
    {
        damageSystem.OnHurt += Slap;
    }

    void Slap()
    {
        //pioneer.Play();
        AudioSource.PlayClipAtPoint(pioneer.clip, transform.position);
    }
}

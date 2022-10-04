using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StepSounding : MonoBehaviour
{
    private CharacterController player;
    private AudioSource audioSource;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if(player.velocity.magnitude > 0 && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
        else if(player.velocity.magnitude <= 0 && audioSource.isPlaying == true)
        {
            audioSource.Stop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioSource doorSoundSource;
    [SerializeField] Button barButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            doorSoundSource.Play();
            barButton.enabled = true;
            barButton.image.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        barButton.enabled = false;
        barButton.image.enabled = false;
    }
}

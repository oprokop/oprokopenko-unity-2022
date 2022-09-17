using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamerasChanging : MonoBehaviour
{
    public List<GameObject> camerasToDisable;

    public GameObject cameraToEnable;

    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            DisableCameras();
            cameraToEnable.SetActive(true);
        });
    }

    private void DisableCameras()
    {
        if (camerasToDisable.Capacity > 0)
        {
            for (int i = 0; i < camerasToDisable.Capacity; i++)
            {
                camerasToDisable[i].SetActive(false);
            }
        }
    }
}

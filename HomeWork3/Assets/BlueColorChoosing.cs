using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlueColorChoosing : MonoBehaviour
{
    public GameObject[] objects;

    public Button button;
   
    private MeshRenderer meshRenderer;

    private void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].activeSelf)
            {
                meshRenderer = objects[i].GetComponent<MeshRenderer>();
                button.onClick.AddListener(() => { meshRenderer.material.color = Color.blue; });
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackToMain : MonoBehaviour
{
    public Button buttonBack;
    public Canvas canvasFrom;
    public Canvas canvasBack;

    void Start()
    {
        buttonBack = GetComponent<Button>();
        buttonBack.onClick.AddListener(() => { 
            canvasFrom.gameObject.SetActive(false); 
            canvasBack.gameObject.SetActive(true);
        });
    }
}

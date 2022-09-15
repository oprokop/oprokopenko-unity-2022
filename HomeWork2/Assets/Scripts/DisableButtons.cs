using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisableButtons : MonoBehaviour
{
    public Button button;
    public Button button1;
    public Button button2;
    void Start()
    {
        //button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            button.gameObject.GetComponent<Button>().interactable = false;
            button1.gameObject.GetComponent<Button>().interactable = false;
            button2.gameObject.GetComponent<Button>().interactable = false;
        });
    }
}

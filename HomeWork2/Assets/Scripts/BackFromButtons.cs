using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackFromButtons : MonoBehaviour
{
    public Button buttonBack;
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonDisable;
    public Canvas canvasFrom;
    public Canvas canvasBack;
    void Start()
    {
        buttonBack = GetComponent<Button>();
        buttonBack.onClick.AddListener(() => { 
            buttonOne.gameObject.GetComponent<Button>().interactable = true; 
            buttonTwo.gameObject.GetComponent<Button>().interactable = true; 
            buttonDisable.gameObject.GetComponent<Button>().interactable = true;
            canvasFrom.gameObject.SetActive(false); 
            canvasBack.gameObject.SetActive(true);
        });
    }
}

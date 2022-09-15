using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChanger : MonoBehaviour
{
    public Button button;
    public TMP_Text buttonText;
    public TMP_Text underText;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { underText.text = $"{buttonText.text} clicked"; });
    }
}


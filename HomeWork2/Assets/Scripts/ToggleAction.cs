using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleAction : MonoBehaviour
{
    public Toggle activeToggle;
    public Text labelText;
    public TMP_Text underText;

    void Start()
    {
        activeToggle = GetComponent<Toggle>();
        activeToggle.onValueChanged.AddListener(delegate {ToUnderText(activeToggle);} );
    }

    void ToUnderText(Toggle tg)
    {
        if (tg.isOn)
        {
            underText.text = labelText.text;
        }
    }
}

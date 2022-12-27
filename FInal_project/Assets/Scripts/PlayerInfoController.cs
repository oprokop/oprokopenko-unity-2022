using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerInfoController : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;

    void Awake()
    {
        nameInput.text = PlayerPrefs.GetString("Username");
    }
    public string GetName()
    {
        return nameInput.text;
    }
}

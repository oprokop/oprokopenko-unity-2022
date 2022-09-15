using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropTextChanger : MonoBehaviour
{
    public TMP_Text underDropsText;
    
    public void HandleInputData(int value)
    {
        if (value == 0)
        {
            underDropsText.text = "Option A";
        }
        else if (value == 1)
        {
            underDropsText.text = "Option B";
        }
        else if (value == 2)
        {
            underDropsText.text = "Option C";
        }
        else if (value == 3)
        {
            underDropsText.text = "Option D";
        }
    }
}


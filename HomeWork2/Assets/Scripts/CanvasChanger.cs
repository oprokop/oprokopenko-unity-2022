using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChanger : MonoBehaviour
{
    public Button button;
    public List<Canvas> canvasFrom;
    public Canvas canvasTo;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { canvasTo.gameObject.SetActive(true); } );
        button.onClick.AddListener( delegate { DisableAllTheRest(); } );
    }

    void DisableAllTheRest()
    {
        foreach(Canvas canvas in canvasFrom)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}

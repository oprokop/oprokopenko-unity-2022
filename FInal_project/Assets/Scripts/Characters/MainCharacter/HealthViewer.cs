using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] DamageSystem damageSystem;

    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(damageSystem.Health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}

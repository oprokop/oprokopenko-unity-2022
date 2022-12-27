using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] int sceneNumber;
    [SerializeField] DamageSystem damageSystem;
    [SerializeField] PlayerInfoController playerInfo;
    public void OnButtonClick()
    {
        if (sceneNumber != 0 && sceneNumber != 1)
        {
            if (damageSystem.gameObject.layer == 6)
            {
                PlayerPrefs.SetInt("Health", damageSystem.Health);
            }
        }
        if(sceneNumber == 1)
        {
            PlayerPrefs.SetString("Username", playerInfo.GetName());
        }
        SceneManager.LoadScene(sceneNumber);
    }
}

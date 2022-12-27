using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Ending ending;
    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas deathCanvas;
    [SerializeField] Canvas endingCanvas;
    [SerializeField] Canvas healthCanvas;
    [SerializeField] TMP_Text username;
    [SerializeField] DamageSystem damageSystem;

    void Awake()
    {
        damageSystem.OnFatalHurt += ShowDeathScreen;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            ending.onEnd += EndCase;
        }
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        mainCanvas.enabled = false;
        pauseCanvas.enabled = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        mainCanvas.enabled = true;
        pauseCanvas.enabled = false;
    }

    public void Home()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Health", 5);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShowDeathScreen()
    {
        Time.timeScale = 0.0f;
        mainCanvas.enabled = false;
        deathCanvas.enabled = true;
    }

    void EndCase()
    {
        Time.timeScale = 0.0f;
        username.text = PlayerPrefs.GetString("Username");
        mainCanvas.enabled = false;
        healthCanvas.enabled = false;
        endingCanvas.enabled = true;
    }
}

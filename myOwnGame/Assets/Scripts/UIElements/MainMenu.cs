using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameSelectSound = "Select";
    public string nameClickSound = "Click";

    AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No audiomanager found!");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnMouseSelect()
    {
        audioManager.PlaySound(nameSelectSound);
    }

    public void OnMouseClick()
    {
        audioManager.PlaySound(nameClickSound);
    }

    public void ChangeScreen()
    {
        Screen.SetResolution(1280, 720, false);
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameSelectSound = "Select";
    public string nameClickSound = "Click";

    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        if (audioManager == null)
        {
            Debug.Log("No audiomanager found!");
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnMouseClick()
    {
        audioManager.PlaySound(nameClickSound);
    }

    public void OnMouseSelect()
    {
        audioManager.PlaySound(nameSelectSound);
    }
}

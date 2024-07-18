using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameSelectSound = "Select";
    public string nameClickSound = "Click";

    [SerializeField] private Token token;
    [SerializeField] private ArenaConfig arenaConfig;

    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        if (audioManager == null)
        {
            Debug.Log("No audiomanager found!");
        }
    }

    public void LaunchArena(int tokenAmount)
    {
        if (token.amount >= tokenAmount)
        {
            token.amount -= tokenAmount;
            SceneManager.LoadScene(1);
        }
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

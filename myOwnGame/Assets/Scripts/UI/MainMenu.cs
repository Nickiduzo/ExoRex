using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameSelectSound = "Select";
    public string nameClickSound = "Click";

    [SerializeField] private Token token;
    [SerializeField] private ArenaConfig arenaConfig;

    private void OnEnable()
    {
        AudioManager.Instance.PlaySound("MenuMusic");
        AudioManager.Instance.StopSound("ArenaMusic");
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
        AudioManager.Instance.PlaySound(nameClickSound);
    }

    public void OnMouseSelect()
    {
        AudioManager.Instance.PlaySound(nameSelectSound);
    }
}

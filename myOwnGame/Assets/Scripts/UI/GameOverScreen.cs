using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private PointCounter gameCounter;
    [SerializeField] private TextMeshProUGUI resultCounter;

    [SerializeField] private Token token;
    [SerializeField] private ArenaConfig arenaConfig;

    private void Start()
    {
        ActivatePanels();
        player.OnPlayerDeath += HandlePlayerDeath;
    }

    private void Setup(int score)
    {
        Time.timeScale = 0f;
        DeActivatePanels();
        resultCounter.text = "Score: " + score.ToString();
    }
    private void ActivatePanels()
    {
        foreach (GameObject panel in panels)
        {
            if (panel.name != "PanelOver")
            {
                panel.SetActive(true);
            }
        }
    }

    private void DeActivatePanels()
    {
        foreach (GameObject panel in panels)
        {
            if (panel.name == "PanelOver") 
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }
    private void HandlePlayerDeath()
    {
        Setup(gameCounter.ReturnFullScore());
    }
    public void RestartButton()
    {
        int requiredTokens = 0;

        switch (arenaConfig.currentDifficulty)
        {
            case ArenaDifficulty.Light:
                requiredTokens = 1;
                break;
            case ArenaDifficulty.Medium:
                requiredTokens = 2;
                break;
            case ArenaDifficulty.Hard:
                requiredTokens = 3;
                break;
        }

        if (token.amount >= requiredTokens)
        {
            token.amount -= requiredTokens;
            Time.timeScale = 1f;
            DeactivateEvent();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private void DeactivateEvent() => player.OnPlayerDeath -= HandlePlayerDeath;    
    public void ExitButton()
    {
        Time.timeScale = 1f;
        DeactivateEvent();
        SceneManager.LoadScene(0);
    }
}

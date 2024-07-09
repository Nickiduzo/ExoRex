using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private PlayerHealth player;
    [SerializeField] private PointCounter gameCounter;
    [SerializeField] private TextMeshProUGUI resultCounter;
    
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

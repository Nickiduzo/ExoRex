using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private UserPanel userPanel;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !userPanel.unActivePanel)
        {
            if (gameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu(int menuIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

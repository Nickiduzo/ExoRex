using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string pauseButtonClick;
    public string pauseButtonSelect;
    public static bool gameIsPaused = false;
    
    [SerializeField] private GameObject pauseMenuUI;

    private AudioManager audioManager;
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("Pause sounds not found");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void CloseGame()
    {
        Application.Quit();
    }

    public void OnSelectButton()
    {
        audioManager.PlaySound(pauseButtonSelect);
    }

    public void OnClickButton()
    {
        audioManager.PlaySound(pauseButtonClick);
    }
}

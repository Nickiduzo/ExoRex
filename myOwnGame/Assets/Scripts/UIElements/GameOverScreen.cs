using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textmeshpro;

    public string gameoverSelectButton = "Select";
    public string gameoverClickButton = "Click";

    AudioManager audioManager;
    public Transform generalScore;

    [SerializeField] private GameObject bossBarScrene;
    private void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("GameOverScrene not found our music");
        }
    }
    public void Setup(int score)
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        bossBarScrene.SetActive(false);
        generalScore.gameObject.SetActive(false);
        textmeshpro.text += score.ToString();
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void OnMouseSelect()
    {
        audioManager.PlaySound(gameoverSelectButton);
    }

    public void OnMouseClick()
    {
        audioManager.PlaySound(gameoverClickButton);
    }
}

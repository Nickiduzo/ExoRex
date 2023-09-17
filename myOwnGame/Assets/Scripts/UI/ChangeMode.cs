using UnityEngine;

public class ChangeMode : MonoBehaviour
{
    public static ChangeMode instance;
    
    [HideInInspector] public int difficulty;

    private void Awake()
    {
        instance = this;
    }

    public void SaveDifficult()
    {
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.Save();
        Debug.Log("Difficult: " + difficulty);
    }
    public void SwitchLowMode()
    {
        difficulty = 150;
    }
   
    public void SwitchMediumMode()
    {
        difficulty = 100;
    }

    public void SwitchHighMode()
    {
        difficulty = 50;
    }
}

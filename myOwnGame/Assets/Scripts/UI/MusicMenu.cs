using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    public void ChangeGeneralSlider(float generalValue)
    {
        AudioListener.volume = generalValue;
    }
}

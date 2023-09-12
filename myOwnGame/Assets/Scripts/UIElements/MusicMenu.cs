using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicMenu : MonoBehaviour
{
    public void ChangeGeneralSlider(float generalValue)
    {
        AudioListener.volume = generalValue;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class BossBarElement : MonoBehaviour
{
    [SerializeField] private PointCounter pointCounter;
    [SerializeField] private Slider slider;
    public void ActivateBossBar()
    {
        slider.value = slider.maxValue;
        gameObject.SetActive(true);
    }
    public void OnDestroy()
    {
        gameObject.SetActive(false);
    }
    public void SetMainValue(float value) => slider.value = slider.value - value;
}

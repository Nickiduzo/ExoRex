using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPro;
    private static int count;
    private float timerToIncrease;
    public static PointCounter Instanse { get ; private set; }
    private void Start()
    {
        count = 0;
        timerToIncrease = 1;
        textPro = GetComponent<TextMeshProUGUI>();
    }
    private void Awake()
    {
        Instanse = this;
    }
    private void Update()
    {
        if(timerToIncrease != 0)
            timerToIncrease -= Time.deltaTime;

        textPro.text = count.ToString();
    }
    public void UpdateKillCount(int score)
    {
        if (timerToIncrease <= 0)
        {
            count += score;
            timerToIncrease = 1;
        }
    }
    public static int ReturnFullScore()
    {
        return count;
    }
}

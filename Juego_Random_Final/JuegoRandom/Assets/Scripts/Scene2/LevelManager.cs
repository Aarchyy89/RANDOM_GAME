using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TMP_Text timer_txt;

    public GameObject Finished_game_panel;

    public float tiempo_Total;

    public int minutes;
    public int seconds;

    public static LevelManager INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    private void Update()
    {
        tiempo_Total -= Time.deltaTime;

        timer_txt.text = tiempo_Total.ToString();

        minutes = (int)(tiempo_Total / 60);
        seconds = (int)(tiempo_Total - minutes * 60);

        timer_txt.text = string.Format("{0:00}:{1:00}", minutes,
        seconds);

        if (tiempo_Total <= 0)
        {
            FinishedGAME();
        }

    }

    public void FinishedGAME()
    {
        Finished_game_panel.SetActive(true);
        Time.timeScale = 0;
    }
}

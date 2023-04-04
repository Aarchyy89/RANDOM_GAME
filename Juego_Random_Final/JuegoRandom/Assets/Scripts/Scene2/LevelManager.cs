using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TMP_Text timer_txt;
    public TMP_Text Destroyed_dianas_txt;

    public GameObject Finished_game_panel;
    public GameObject Panel_Pause;

    public float tiempo_Total;

    public bool Pausedgame;

    public int minutes;
    public int seconds;

    public int Destroyed_Dianas;
    public int Max_Destroyed_Dianas;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (tiempo_Total <= 0)
        {
            FinishedGAME();
        }

        if(Destroyed_Dianas == Max_Destroyed_Dianas && Portal.instance.Finish == true)
        {
            Finished_game_panel.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void PauseGame()
    {
        Pausedgame = !Pausedgame;
        if (!Pausedgame)
        {
            Panel_Pause.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            Panel_Pause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void FinishedGAME()
    {
        Finished_game_panel.SetActive(true);
        Time.timeScale = 0;
    }
}

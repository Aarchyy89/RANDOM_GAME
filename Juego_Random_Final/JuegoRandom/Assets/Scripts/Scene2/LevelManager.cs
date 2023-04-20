using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TMP_Text timer_txt;
    public TMP_Text Destroyed_dianas_txt;

    public GameObject Lose_panel;
    public GameObject Win_panel;
    public GameObject Panel_Pause;
    public GameObject Meta;

    [SerializeField] private AudioClip Defeat;
    [SerializeField] private AudioClip Victory;

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
            Audio_Manager.instance.audioSource.Stop();
            Audio_Manager.instance.AudioClip(Victory);
            Win_panel.SetActive(true);
            Time.timeScale = 0;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            Meta.SetActive(true);
            Destroyed_Dianas += 3;
            Destroyed_dianas_txt.text = Destroyed_Dianas + "";
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
        Audio_Manager.instance.audioSource.Stop();
        Audio_Manager.instance.AudioClip(Defeat);
        Lose_panel.SetActive(true);
        Time.timeScale = 0;
    }
    
    
}

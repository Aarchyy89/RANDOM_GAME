using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("---Paneles---")]
    public GameObject pause_panel;
    public GameObject options_panel;
    public GameObject controls_panel;
    public GameObject Fiished_panel;

    public void Resume()
    {
        Time.timeScale = 1;
        pause_panel.SetActive(false);
    }

    public void Controls()
    {
        controls_panel.SetActive(true); 
    }

    public void Options()
    {
        options_panel.SetActive(true);
    }

    public void ReturnPause()
    {
        options_panel.SetActive(false);
        controls_panel.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

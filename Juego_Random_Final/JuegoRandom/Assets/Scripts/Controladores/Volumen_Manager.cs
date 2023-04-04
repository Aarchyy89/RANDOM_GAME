using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Volumen_Manager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeTextUI;

    /**public Button save_but;
    public Button MainMenu_but;
    public Button brightness_but;
    public Button settings_but;*/

    public GameObject volume_panel;

    public GameObject no_volume;


    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        if (volume == 0f)
        {
            no_volume.SetActive(true);
        }
        else
        {
            no_volume.SetActive(false);
        }
        volumeTextUI.text = volume.ToString("0.0");
    }


    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {

        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    /**public void Activartodo()
    {
        volume_panel.SetActive(true);
        MainMenu_but.gameObject.SetActive(false);
        brightness_but.gameObject.SetActive(false);
        settings_but.gameObject.SetActive(false);
    }*/
}

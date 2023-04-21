using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("---Portales---")]
    public GameObject portal;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject portal4;
    public GameObject portal5;
    public GameObject portal6;
    public GameObject portal7;
    public GameObject portal8;
    public GameObject portal9;
    public GameObject portal10;
    public GameObject portal11;
    public GameObject portal12;
    public GameObject portal13;
    public GameObject portal14;
    public GameObject portal15;
    public GameObject Meta;

    public bool Finish = false;

    [SerializeField] private AudioClip clip;

    public static Portal instance;

    private void Awake()
    {
        instance = this;
    }
    #region portals
    public void Portal2()
    {
        LevelManager.INSTANCE.tiempo_Total += 20f;
        Audio_Manager.instance.AudioClip(clip);
        portal2.SetActive(true);
        portal.SetActive(false);
    }

    public void Portal3()
    {
        LevelManager.INSTANCE.tiempo_Total += 20f;
        Audio_Manager.instance.AudioClip(clip);
        portal3.SetActive(true);
        portal2.SetActive(false);
    }

    public void Portal4()
    {
        LevelManager.INSTANCE.tiempo_Total += 20f;
        Audio_Manager.instance.AudioClip(clip);
        portal4.SetActive(true);
        portal3.SetActive(false);
    }

    public void Portal5()
    {
        LevelManager.INSTANCE.tiempo_Total += 15f;
        Audio_Manager.instance.AudioClip(clip);
        portal5.SetActive(true);
        portal4.SetActive(false);
    }

    public void Portal6()
    {
        LevelManager.INSTANCE.tiempo_Total += 15f;
        Audio_Manager.instance.AudioClip(clip);
        portal6.SetActive(true);
        portal5.SetActive(false);
    }

    public void Portal7()
    {
        LevelManager.INSTANCE.tiempo_Total += 12f;
        Audio_Manager.instance.AudioClip(clip);
        portal7.SetActive(true);
        portal6.SetActive(false);
    }

    public void Portal8()
    {
        LevelManager.INSTANCE.tiempo_Total += 12f;
        Audio_Manager.instance.AudioClip(clip);
        portal8.SetActive(true);
        portal7.SetActive(false);
    }

    public void Portal9()
    {
        LevelManager.INSTANCE.tiempo_Total += 12f;
        Audio_Manager.instance.AudioClip(clip);
        portal9.SetActive(true);
        portal8.SetActive(false);
    }

    public void Portal10()
    {
        LevelManager.INSTANCE.tiempo_Total += 12f;
        Audio_Manager.instance.AudioClip(clip);
        portal10.SetActive(true);
        portal9.SetActive(false);
    }

    public void Portal11()
    {
        LevelManager.INSTANCE.tiempo_Total += 8f;
        Audio_Manager.instance.AudioClip(clip);
        portal11.SetActive(true);
        portal10.SetActive(false);
    }

    public void Portal12()
    {
        LevelManager.INSTANCE.tiempo_Total += 5f;
        Audio_Manager.instance.AudioClip(clip);
        portal12.SetActive(true);
        portal11.SetActive(false);
    }

    public void Portal13()
    {
        LevelManager.INSTANCE.tiempo_Total += 5f;
        Audio_Manager.instance.AudioClip(clip);
        portal13.SetActive(true);
        portal12.SetActive(false);
    }

    public void Portal14()
    {
        LevelManager.INSTANCE.tiempo_Total += 5f;
        Audio_Manager.instance.AudioClip(clip);
        portal14.SetActive(true);
        portal13.SetActive(false);
    }

    public void Portal15()
    {
        LevelManager.INSTANCE.tiempo_Total += 10f;
        Audio_Manager.instance.AudioClip(clip);
        portal15.SetActive(true);
        portal14.SetActive(false);
    }
    #endregion

    public void ActivarMeta()
    {
        LevelManager.INSTANCE.tiempo_Total += 25f;
        Audio_Manager.instance.AudioClip(clip);
        Meta.SetActive(true);
        portal15.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Portal2();
            Portal3();
            Portal4();
            Portal5();
            Portal6();
            Portal7();
            Portal8();
            Portal9();
            Portal10();
            Portal11();
            Portal12();
            Portal13();
            Portal14();
            Portal15();
            ActivarMeta();
        }
    }

}

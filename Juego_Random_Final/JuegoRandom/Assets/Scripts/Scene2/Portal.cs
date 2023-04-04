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
    public GameObject Meta;


    public void Portal2()
    {
        LevelManager.INSTANCE.tiempo_Total += 5f;
        portal2.SetActive(true);
        portal.SetActive(false);
    }

    public void Portal3()
    {
        LevelManager.INSTANCE.tiempo_Total += 10f;
        portal3.SetActive(true);
        portal2.SetActive(false);
    }

    public void Portal4()
    {
        LevelManager.INSTANCE.tiempo_Total += 15f;
        portal4.SetActive(true);
        portal3.SetActive(false);
    }

    public void Portal5()
    {
        LevelManager.INSTANCE.tiempo_Total += 20f;
        portal5.SetActive(true);
        portal4.SetActive(false);
    }

    public void ActivarMeta()
    {
        LevelManager.INSTANCE.tiempo_Total += 25f;
        Meta.SetActive(true);
        portal5.SetActive(false);
    }

    /**public void HasLlegadoAMeta()
    {
        Meta.SetActive(false);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Portal2();
            Portal3();
            Portal4();
            Portal5();
            ActivarMeta();
            //HasLlegadoAMeta();
        }
    }

}

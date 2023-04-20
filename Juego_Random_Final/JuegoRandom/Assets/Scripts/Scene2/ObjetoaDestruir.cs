using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoaDestruir : MonoBehaviour
{

    [SerializeField] private AudioClip clip;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            Audio_Manager.instance.AudioClip(clip);
            LevelManager.INSTANCE.Destroyed_Dianas += 1;
            LevelManager.INSTANCE.Destroyed_dianas_txt.text = LevelManager.INSTANCE.Destroyed_Dianas + "";
            Destroy(gameObject);
        }
    }


}

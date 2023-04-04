using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoaDestruir : MonoBehaviour
{
    //para la colision accedo a la void ontrigger y le pregunto quien es el otro 
    /**private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Proyectil"))
        {
            LevelManager.INSTANCE.Destroyed_Dianas += 1;
            LevelManager.INSTANCE.Destroyed_dianas_txt.text = LevelManager.INSTANCE.Destroyed_Dianas + "";
            Destroy(gameObject);
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            LevelManager.INSTANCE.Destroyed_Dianas += 1;
            LevelManager.INSTANCE.Destroyed_dianas_txt.text = LevelManager.INSTANCE.Destroyed_Dianas + "";
            Destroy(gameObject);
        }
    }


}

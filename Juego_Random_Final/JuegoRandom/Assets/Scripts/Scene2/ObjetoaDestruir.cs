using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoaDestruir : MonoBehaviour
{
    //para la colision accedo a la void ontrigger y le pregunto quien es el otro 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Proyectil"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    /**private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Hola");
            Destroy(gameObject);
        }
    }*/


}

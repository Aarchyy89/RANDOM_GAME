using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject lose_panel;

    private void OnTriggerEnter(Collider other)
    {
        //si ese otro tiene el tag de proyectil destruyo al otro y a mi mismo 
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Death());
        }

        
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(5f);

        WizController.instance.anim.SetTrigger("Death");
        Time.timeScale = 0;
        lose_panel.SetActive(true);
    }
}

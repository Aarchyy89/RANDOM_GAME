using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject Metaaa;

    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HasLlegadoAMeta();
        }
    }

    public void HasLlegadoAMeta()
    {
        Portal.instance.Finish = true;
        Audio_Manager.instance.AudioClip(clip);
        Metaaa.SetActive(false);
    }
}

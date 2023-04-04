using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Backgroundmusic;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            AudioClip(Backgroundmusic);

        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void AudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

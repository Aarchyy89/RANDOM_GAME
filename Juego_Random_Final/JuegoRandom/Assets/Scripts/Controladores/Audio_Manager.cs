using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
    public AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            AudioClip(clip);

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

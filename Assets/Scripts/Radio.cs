using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public bool randomPlay = false; 
    public AudioClip[] titleScreenMainMusicAndNews;
    private AudioSource audioSource;
    int clipOrder = 0; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            // if randomPlay est séléctionné
            if (randomPlay == true)
            {
                audioSource.clip = GetRandomClip();
                audioSource.Play();
                
            }
            // if randomPlay n'est pas séléctionné
            else
            {
                audioSource.clip = GetNextClip();
                audioSource.Play();
            }

        }
    }

    // Fonction pour lire les sons aléatoirement.
    private AudioClip GetRandomClip()
    {
        return titleScreenMainMusicAndNews[Random.Range(0, titleScreenMainMusicAndNews.Length)];
    }

    // Fonction pour lire les sons dans l'ordre et les répéter une fois la playlist terminée.
    private AudioClip GetNextClip()
    {
        if (clipOrder >= titleScreenMainMusicAndNews.Length - 1)
        {
            clipOrder = 0;
        }
        else
        {
            clipOrder += 1;
        }
        return titleScreenMainMusicAndNews[clipOrder];
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}

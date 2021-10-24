using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource musicSource; 
    public AudioClip musicClip; 
    public AudioClip sfxClip; 
    
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
       // if (lifeValue == 0)
      //  musicSource.clip = sfxClip; 
       // musicSource.Play(); 
        
    }
}

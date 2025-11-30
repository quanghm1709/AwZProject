using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> 
{
    public static AudioManager instance;
    public bool musicOn = true;
    public bool sfxOn = true;
    public AudioUI audioUI;

    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    private void Start()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void MusicAction(bool turnOn)
    {
        musicOn = turnOn;
        if(musicOn)
        {
            music.volume = 1;
        }
        else
        {
            music.volume = 0;
        }
    }

    public void SfxAction(bool turnOn) 
    {
        sfxOn = turnOn;
        if (sfxOn)
        {
            sfx.volume = 1;
        }
        else
        {
            sfx.volume = 0; 
        }
    }

    public void RunMusic()
    {
        if (musicOn)
        {
            music.Play();
        }
        else
        {
            music.Stop();   
        }
    }

    public void RunSfx()
    {
        if(sfxOn)
        {
            sfx.Play();
        }
        else
        {
            sfx.Stop();
        }
    }
}

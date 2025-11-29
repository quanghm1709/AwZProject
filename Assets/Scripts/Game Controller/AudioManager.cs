using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool musicOn = true;
    public bool sfxOn = true;

    private void Awake()
    {
        if (this == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void MusicAction(bool turnOn)
    {
        musicOn = turnOn;
    }

    public void SfxAction(bool turnOn) {sfxOn = turnOn;}
}

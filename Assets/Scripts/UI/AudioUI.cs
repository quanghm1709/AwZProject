using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle sfxToggle;

    private void Start()
    {
        if (AudioManager.Instance.musicOn)
        {
            musicToggle.isOn = true;
        }
        else
        {
            musicToggle.isOn = false;
        }

        if(AudioManager.Instance.sfxOn)
        {
            sfxToggle.isOn = true;
        }
        else
        {
            sfxToggle.isOn = false;
        }
    }

    public void MusicAction(bool turnOn)
    {
        if(musicToggle.isOn) 
            AudioManager.Instance.MusicAction(true);
        else
            AudioManager.Instance.MusicAction(false);
    }

    public void SfxAction(bool turnOn)
    {
        if(sfxToggle.isOn)
            AudioManager.Instance.SfxAction(true);
        else
            AudioManager.Instance.SfxAction(false);
    }
}

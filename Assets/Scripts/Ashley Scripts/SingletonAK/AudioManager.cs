using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource jumpSound;
    public AudioSource deathSound;

    public void PlaySound(AudioSource clip)
    {
       
        clip.Play();
    }

    public void PlayMusic(AudioSource clipM)
    {
        clipM.Play();
        DontDestroyOnLoad(clipM);
    }





}

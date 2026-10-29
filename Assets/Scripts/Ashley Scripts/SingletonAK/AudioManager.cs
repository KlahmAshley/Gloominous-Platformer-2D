using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource orbPickupSound;
    public AudioSource powerUpSound;


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

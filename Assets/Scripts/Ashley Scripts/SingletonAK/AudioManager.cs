using UnityEngine;

public class AudioManager : Singleton<AudioManager>

{
    public void PlaySound(AudioSource clip)
    {
       
        clip.Play();
    }

    public void PlayMusic(AudioSource clipM)
    {
        clipM.Play();   
    }





}

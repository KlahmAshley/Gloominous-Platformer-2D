using UnityEngine;

public class AudioManager : Singleton<AudioManager>

{
    public AudioSource SfxSound;
    public AudioSource Music;

    public void PlaySound(AudioClip clip)
    {
        SfxSound.clip = clip;
        SfxSound.Play();
    }

    public void PlayMusic(AudioClip clipM)
    {
        Music.clip = clipM;
        Music.Play();
    }





}

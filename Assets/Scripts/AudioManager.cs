using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region //Singleton
    public static AudioManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public AudioClip[] soundEffects;
    public AudioClip[] musicTracks;

    AudioClip sound;

    public static void PlaySound(int soundIndex)
    {
        //create a sound source, play the clip, delete the component

    }

    public static void PlaySound(AudioClip sound)
    {
        //create a sound source, play the clip, delete the component
    }

    public static void PlayMusic(int musicIndex)
    {
        //create a sound source, play the clip, delete the component
    }

    public void onDisable()
    {
        instance = null;
    }


}

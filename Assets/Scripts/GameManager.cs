using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        Fader.instance.FadeToNextScene();


    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();


    }

    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Volume);
    }

}

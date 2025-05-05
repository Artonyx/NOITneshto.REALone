using System.Collections;
using UnityEngine;

public class soundEffects : MonoBehaviour
{
    public AudioSource audio;

    public void playButton()
    {
        audio.Play();
        /*while (audio.isPlaying == true)
        {
            yield return null;
        }*/
    }

    public void settingsButton()
    {
        audio.Play();
    }
}

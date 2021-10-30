using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
   public AudioMixer audioMixer;
   public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MyExposedParam", volume);
    }
}

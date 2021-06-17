using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneOffSound : MonoBehaviour
{
    [SerializeField]
    OneOffSoundPool pool = null;

    [SerializeField]
    AudioClip clip = null;

    [SerializeField]
    float volume = 0;

    public void PlaySound()
    {
        var sound = pool.GetObject();
        sound.Clip = clip;
        sound.Volume = volume;
        sound.gameObject.SetActive(true);
    }
}

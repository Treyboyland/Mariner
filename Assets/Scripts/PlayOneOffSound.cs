using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneOffSound : MonoBehaviour
{
    [SerializeField]
    OneOffSoundPool pool;

    [SerializeField]
    AudioClip clip;

    [SerializeField]
    float volume;

    public void PlaySound()
    {
        var sound = pool.GetObject();
        sound.Clip = clip;
        sound.Volume = volume;
        sound.gameObject.SetActive(true);
    }
}

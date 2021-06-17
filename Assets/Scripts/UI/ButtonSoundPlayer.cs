using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource source = null;

    [SerializeField]
    AudioClip clip = null;

    public void Play()
    {
        source.PlayOneShot(clip);
    }
}

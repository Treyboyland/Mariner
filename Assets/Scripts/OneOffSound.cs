using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneOffSound : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    public AudioClip Clip
    {
        set
        {
            source.clip = value;
        }
    }

    public float Volume { set { source.volume = value; } }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }


    IEnumerator WaitThenDisable()
    {
        while (source.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}

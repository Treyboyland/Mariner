using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizerFade : AudioRandomizer
{
    [SerializeField]
    Vector2 volume;

    [SerializeField]
    Vector2 pitch;

    [SerializeField]
    Vector2 fadeInTime;

    public override void RandomizeSource(AudioSource source)
    {
        StartCoroutine(RandomizeSourceWaitThenDisable(source));
    }

    public IEnumerator RandomizeSourceWaitThenDisable(AudioSource source)
    {
        source.pitch = RandomX.Range(pitch);
        float endVolume = RandomX.Range(volume);
        float secondsToWait = RandomX.Range(fadeInTime);
        float elapsed = 0;
        source.Play();

        while (elapsed < secondsToWait)
        {
            elapsed += Time.deltaTime;
            source.volume = Mathf.Lerp(0, endVolume, elapsed / secondsToWait);
            yield return null;
        }

        while (source.isPlaying)
        {
            yield return null;
        }

        source.gameObject.SetActive(false);
    }
}



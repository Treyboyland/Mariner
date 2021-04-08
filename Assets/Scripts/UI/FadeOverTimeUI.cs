using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOverTimeUI : MonoBehaviour
{
    [SerializeField]
    float secondsToWait = 0;

    /// <summary>
    /// Seconds to wait before fading
    /// </summary>
    /// <value></value>
    public float SecondsToWait
    {
        get
        {
            return secondsToWait;
        }
        set
        {
            secondsToWait = value;
        }
    }

    [SerializeField]
    float secondsToFade = 0;

    [SerializeField]
    TextMeshProUGUI text;


    /// <summary>
    /// Seconds to fade the text
    /// </summary>
    /// <value></value>
    public float SecondsToFade
    {
        get
        {
            return secondsToFade;
        }
        set
        {
            secondsToFade = value;
        }
    }

    void SetAlpha(float alpha)
    {
        var color = text.color;
        color.a = alpha;
        text.color = color;
    }

    public void StartFade()
    {
        if (gameObject.activeInHierarchy)
        {
            StopAllCoroutines();
            StartCoroutine(Fade());
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


    private void OnEnable()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        SetAlpha(1);
        yield return new WaitForSeconds(secondsToWait);
        float elapsed = 0;

        while (elapsed < secondsToFade)
        {
            elapsed += Time.deltaTime;
            SetAlpha(Mathf.Lerp(1, 0, elapsed / secondsToFade));
            yield return null;
        }

        SetAlpha(0);
        gameObject.SetActive(false);

    }
}

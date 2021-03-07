using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticlesAfterFinished : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps = null;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        while (ps.isPlaying)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}

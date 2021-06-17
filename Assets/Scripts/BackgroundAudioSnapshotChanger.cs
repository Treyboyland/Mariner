using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BackgroundAudioSnapshotChanger : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer = null;

    [SerializeField]
    AudioMixerSnapshot initialSnapshot = null;

    [SerializeField]
    AudioMixerSnapshot deepSnapshot = null;

    [SerializeField]
    PlayerDepth playerDepth = null;

    [SerializeField]
    float bottomDepthChange = 0;

    [SerializeField]
    float topDepthChange = 0;

    [SerializeField]
    float secondsToWait = 0;

    [SerializeField]
    float secondsToTransition = 0;

    bool isTop = false;

    AudioMixerSnapshot[] snapshots;

    AudioMixerSnapshot[] snapshotsReversed;

    // Start is called before the first frame update
    void Start()
    {
        snapshots = new AudioMixerSnapshot[] { initialSnapshot, deepSnapshot };
        snapshotsReversed = new AudioMixerSnapshot[] { deepSnapshot, initialSnapshot };
    }

    private void Update()
    {
        if (isTop && playerDepth.Depth >= bottomDepthChange)
        {
            //Debug.LogWarning("Swap to deep");
            isTop = false;
            mixer.TransitionToSnapshots(snapshots, new float[] { 0, 1 }, secondsToTransition);
        }
        else if (!isTop && playerDepth.Depth <= topDepthChange)
        {
            //Debug.LogWarning("Swap to top");
            isTop = true;
            mixer.TransitionToSnapshots(snapshotsReversed, new float[] { 0, 1 }, secondsToTransition);
        }
    }

    IEnumerator WaitThenSwapToDeep()
    {
        yield return new WaitForSeconds(secondsToWait);
        mixer.TransitionToSnapshots(snapshots, new float[] { 1, 1 }, secondsToTransition);
    }

    IEnumerator WaitThenSwapToTop()
    {
        yield return new WaitForSeconds(secondsToWait);
        mixer.TransitionToSnapshots(snapshots, new float[] { 1, 1 }, secondsToTransition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField]
    string trigger = "";

    [SerializeField]
    string initialStateName = "";

    [SerializeField]
    bool mustFinishPlayingBeforeTriggeringAgain = true;

    [SerializeField]
    Animator animator = null;

    public void TriggerAnimation()
    {
        if (!mustFinishPlayingBeforeTriggeringAgain ||
            (mustFinishPlayingBeforeTriggeringAgain && animator.GetCurrentAnimatorStateInfo(0).IsName(initialStateName)))
        {
            animator.SetTrigger(trigger);
        }
    }
}

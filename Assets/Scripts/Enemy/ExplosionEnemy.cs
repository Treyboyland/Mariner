using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Enemy
{
    [SerializeField]
    float secondsToAnimate = 0;

    [SerializeField]
    TransformRandomizer randomizer = null;

    [SerializeField]
    GameEventVector2 onExplode = null;

    [SerializeField]
    GameEventVector2 onFizzle = null;

    [SerializeField]
    ParticleSystem explosionPrep;

    bool animating = false;

    public bool FizzleOut { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        animating = false;
        FizzleOut = false;
    }

    public void Explode()
    {
        if (!animating)
        {
            animating = true;
            StartCoroutine(WaitThenExplode());
        }
    }

    IEnumerator WaitThenExplode()
    {
        randomizer.Randomize = true;
        explosionPrep.Play();
        yield return new WaitForSeconds(secondsToAnimate);

        if (FizzleOut)
        {
            onFizzle.Vector = transform.position;
            onFizzle.Invoke();
        }
        else
        {
            onExplode.Vector = transform.position;
            onExplode.Invoke();
        }

        animating = false;
        gameObject.SetActive(false);
    }
}

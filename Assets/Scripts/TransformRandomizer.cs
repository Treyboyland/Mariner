using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRandomizer : MonoBehaviour
{
    Vector3 initial;

    public Vector3 InitialPosition { get { return initial; } }

    [SerializeField]
    float maxOffset;

    public bool Randomize { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDisable()
    {
        Randomize = false;
    }

    private void OnEnable()
    {
        initial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Randomize)
        {
            SetNewRandomPosition();
        }
        else if (transform.position != initial)
        {
            transform.position = initial;
        }
    }

    void SetNewRandomPosition()
    {
        float x, y, z;
        x = Random.Range(0, maxOffset);
        y = Random.Range(0, maxOffset);
        z = Random.Range(0, maxOffset);
        transform.position = initial + new Vector3(x, y, z);
    }
}

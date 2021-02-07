using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    [SerializeField]
    GameObject toTrack = null;

    [SerializeField]
    Vector3 offset = new Vector3();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = toTrack.transform.position + offset;
    }
}

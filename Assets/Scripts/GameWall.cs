using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWall : MonoBehaviour
{
    [SerializeField]
    GameObject objectToScale = null;

    public void SetScale(Vector2 newScale)
    {
        Vector3 scale = newScale;
        scale.z = objectToScale.transform.localScale.z;
        objectToScale.transform.localScale = scale;
    }
}

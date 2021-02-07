using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsMouse : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;


    const float SPRITE_CORRECTION_ANGLE = 90;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = mainCamera.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - pos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + SPRITE_CORRECTION_ANGLE;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

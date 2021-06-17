using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextMatchButton : MonoBehaviour
{
    [SerializeField]
    Image buttonImage = null;

    [SerializeField]
    TextMeshProUGUI text = null;

    // Start is called before the first frame update
    void Start()
    {
        text.color = buttonImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        text.color = buttonImage.color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveDataUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dateBox = null;

    [SerializeField]
    TextMeshProUGUI goldBox = null;

    [SerializeField]
    Image backColor = null;

    [SerializeField]
    Image frontColor = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetData(PlayerDataSO data)
    {
        if (data == null)
        {
            SetDataDefaults();
            return;
        }
    }

    public void SetDataDefaults()
    {
        
    }
}

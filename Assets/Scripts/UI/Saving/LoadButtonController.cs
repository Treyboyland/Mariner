using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButtonController : MonoBehaviour
{
    [SerializeField]
    GameEventInt pageNum;

    [SerializeField]
    PlayerSaveUtility saveUtility;

    [SerializeField]
    List<LoadButton> buttons;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetData()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var index = pageNum.IntValue * buttons.Count + i;
            buttons[i].SetData(index < saveUtility.AllSaves.Count ?
                saveUtility.AllSaves[index].DataSO :
                null);
        }
    }
}

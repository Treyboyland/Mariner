using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButtonController : MonoBehaviour
{
    [SerializeField]
    GameEventInt pageNum = null;

    [SerializeField]
    PlayerSaveUtility saveUtility = null;

    [SerializeField]
    List<LoadButton> buttons = null;

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

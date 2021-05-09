using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    [SerializeField]
    Button button = null;

    [SerializeField]
    TextMeshProUGUI date = null;

    [SerializeField]
    Image backColor = null;

    [SerializeField]
    Image frontColor = null;

    [SerializeField]
    TextMeshProUGUI goldText = null;

    [SerializeField]
    ItemDataSO goldItem = null;

    [SerializeField]
    int id = 0;

    [SerializeField]
    GameEventInt onSaveIndexSelected = null;

    public int Id { get { return id; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetData(PlayerDataSO playerData)
    {
        if (playerData == null)
        {
            SetDefaults();
        }
        else
        {
            SetTextData(playerData);
        }
    }

    void SetDefaults()
    {
        button.interactable = false;
        date.text = "-----------";
        backColor.color = new Color(0, 0, 0, 0);
        frontColor.color = new Color(0, 0, 0, 0);
        goldText.text = "-------------";
    }

    void SetTextData(PlayerDataSO playerData)
    {
        date.text = playerData.SaveTime.ToString();
        goldText.text = "" + playerData.CurrentInventory.GetNumItems(goldItem);
        backColor.color = playerData.BackColor;
        frontColor.color = playerData.FrontColor;
        button.interactable = true;
    }

    public void IndexSelected()
    {
        onSaveIndexSelected.IntValue = id;
        onSaveIndexSelected.Invoke();
    }
}

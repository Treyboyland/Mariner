using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanvasController : MonoBehaviour
{
    [SerializeField]
    PlayerSaveUtility saveData = null;

    bool gamesLoaded = false;

    [SerializeField]
    List<LoadButton> loadButtons = null;

    [SerializeField]
    GameEvent onDataLoaded = null;

    [SerializeField]
    GameEventInt onSavePageIndexChanged = null;

    [SerializeField]
    GameEventInt onButtonSelected = null;

    [SerializeField]
    GameEventInt onNumPagesDetermined = null;

    int maxIndex = 0;

    int index = 0;

    /// <summary>
    /// Current index into all saves
    /// </summary>
    /// <value></value>
    int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
            Debug.LogWarning(gameObject.name + ": New index:" + index);
            onSavePageIndexChanged.IntValue = index;
            onSavePageIndexChanged.Invoke();
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    int GetNumPagesNeeded()
    {
        int i = 0;
        while (loadButtons.Count * i < saveData.AllSaves.Count)
        {
            i++;
        }
        return i;
    }

    public void LoadData()
    {
        if (!gamesLoaded)
        {
            gamesLoaded = true;
            saveData.LoadAllData();
            maxIndex = GetNumPagesNeeded();
            onNumPagesDetermined.IntValue = maxIndex;
            onNumPagesDetermined.Invoke();
        }
        if (maxIndex != GetNumPagesNeeded())
        {
            maxIndex = GetNumPagesNeeded();
            onNumPagesDetermined.IntValue = maxIndex;
            onNumPagesDetermined.Invoke();
        }
        Index = 0;
        onDataLoaded.Invoke();
    }

    public void RefreshData(bool fromMain)
    {
        if (!gamesLoaded)
        {
            gamesLoaded = true;
            saveData.LoadAllData();
            maxIndex = GetNumPagesNeeded();
            onNumPagesDetermined.IntValue = maxIndex;
            onNumPagesDetermined.Invoke();
        }
        else
        {
            maxIndex = GetNumPagesNeeded();
            onNumPagesDetermined.IntValue = maxIndex;
            onNumPagesDetermined.Invoke();
        }
        if (fromMain)
        {
            Index = 0;
        }
        else
        {
            Index = Index >= maxIndex ? maxIndex - 1 : Index;
        }

        onDataLoaded.Invoke();
    }

    public void LoadGame()
    {
        saveData.LoadSave(Index * loadButtons.Count + onButtonSelected.IntValue);
    }

    public void DeleteGame()
    {
        saveData.DeleteSave(Index * loadButtons.Count + onButtonSelected.IntValue);
        RefreshData(false);
    }

    public void IncrementIndex()
    {
        //If next page would be full of blanks, reset
        if (Index + 1 >= maxIndex)
        {
            Index = 0;
        }
        else
        {
            Index++;
        }
    }

    public void DecrementIndex()
    {
        if (Index == 0)
        {
            Index = maxIndex - 1;
        }
        else
        {
            Index--;
        }
    }
}

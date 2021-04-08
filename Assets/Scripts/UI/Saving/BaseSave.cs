using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSave : MonoBehaviour
{
    [SerializeField]
    GameEvent onSaveSuccessful = null;

    [SerializeField]
    GameEvent onSaveNotSuccessful = null;

    [SerializeField]
    Player player;

    [SerializeField]
    SaveLocationSO saveLocation;

    public bool ShouldSave { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SaveGame()
    {
        if (!ShouldSave || saveLocation.SaveLocation.Length == 0)
        {
            return;
        }

        if (PlayerSaveUtility.SaveGame(saveLocation.SaveLocation, player.Data))
        {
            onSaveSuccessful.Invoke();
        }
        else
        {
            onSaveNotSuccessful.Invoke();
        }
    }
}

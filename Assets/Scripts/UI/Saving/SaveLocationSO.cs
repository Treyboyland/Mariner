using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveLocation", menuName = "Misc/Save Location")]
public class SaveLocationSO : ScriptableObject
{
    public string SaveLocation { get; set; }

    private void OnDisable()
    {
        SaveLocation = "";
    }
}

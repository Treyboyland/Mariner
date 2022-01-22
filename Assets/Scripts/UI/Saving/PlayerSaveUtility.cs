using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml.Linq;

public class PlayerSaveUtility : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO toChange = null;

    [SerializeField]
    PlayerDataSO baseData = null;


    [SerializeField]
    SaveLocationSO saveLocation = null;

    [SerializeField]
    List<ItemDataSO> allGameItems = null;

    [SerializeField]
    GameEvent inventoryUpdatedEvent = null;

    [Serializable]
    public struct DataAndPath
    {
        public PlayerDataSO DataSO;
        public string Path;
    }

    List<DataAndPath> allSaves = new List<DataAndPath>();

    public List<DataAndPath> AllSaves
    {
        get
        {
            return allSaves;
        }
    }

    public bool LoadAllData()
    {
        allSaves.Clear();
        try
        {
            //This location should hopefully be platform independent
            foreach (var file in Directory.GetFiles(Application.persistentDataPath))
            {
                if (!file.Contains(".sav"))
                {
                    continue;
                }
                var data = LoadData(file);
                if (data != null)
                {
                    allSaves.Add(new DataAndPath() { DataSO = data, Path = file });
                }
            }
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }
    }

    PlayerDataSO LoadData(string filePath)
    {
        try
        {
            var data = XElement.Parse(File.ReadAllText(filePath));
            PlayerDataSO playerData;
            GameDataXmlExtensions.GetPlayerDataFromXml(data, out playerData, allGameItems, inventoryUpdatedEvent);
            Debug.LogWarning("Read from path \"" + filePath + "\"" + playerData);


            //TODO: Figure out how to save and recover inventory
            if (playerData.CurrentInventory == null)
            {
                Debug.LogWarning("Inventory unable to be restored");
                playerData.CreateNewInventory();
                playerData.CurrentInventory.Copy(baseData.CurrentInventory);
            }


            return playerData;
        }
        catch (Exception e)
        {
            Debug.LogError("Could not parse file \"" + filePath + "\"\r\n" + e);
            return null;
        }
    }

    public void LoadSave(int index)
    {
        if (index >= allSaves.Count)
        {
            return;
        }
        Debug.LogWarning("Initial Data: " + toChange);
        Debug.LogWarning("To Load: " + allSaves[index].DataSO);
        toChange.SetData(allSaves[index].DataSO);
        Debug.LogWarning("Modified Data: " + toChange);
        saveLocation.SaveLocation = allSaves[index].Path;
    }

    public void DeleteSave(int index)
    {
        if (index >= allSaves.Count)
        {
            return;
        }

        try
        {
            System.IO.File.Delete(allSaves[index].Path);
            allSaves.RemoveAt(index);
        }
        catch (Exception e)
        {
            Debug.LogError("Cannot delete file at index " + index + ":\r\n" + e);
        }
    }

    public void CreateSave()
    {
        string saveName = Application.persistentDataPath + "/" +
            "Mariner-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".sav";

        saveLocation.SaveLocation = saveName;

        toChange.SetData(baseData);
        SaveGame(saveName, toChange);
    }

    public static bool SaveGame(string filePath, PlayerDataSO data)
    {
        try
        {
            data.SaveTime = DateTime.Now;
            data.ToXml().Save(filePath);
            Debug.Log("File saved at \"" + filePath + "\"");
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError("Cannot save file to path \"" + filePath + "\"\r\n" + e);
            return false;
        }
    }
}

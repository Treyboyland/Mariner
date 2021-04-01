using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayerSaveUtility : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO toChange = null;

    [SerializeField]
    PlayerDataSO baseData = null;


    [SerializeField]
    SaveLocationSO saveLocation = null;

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
            var data = File.ReadAllText(filePath);
            var playerData = JsonUtility.FromJson<PlayerDataSO>(data);

            return playerData;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return null;
        }
    }

    public void LoadSave(int index)
    {
        if (index >= allSaves.Count)
        {
            return;
        }
        toChange.SetData(allSaves[index].DataSO);
    }

    public void CreateSave()
    {
        string saveName = Application.persistentDataPath + "/" +
            "Mariner-"+ DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".sav";

        saveLocation.SaveLocation = saveName;

        toChange = baseData.Copy();
    }
}

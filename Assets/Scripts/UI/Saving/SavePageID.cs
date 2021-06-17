using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePageID : MonoBehaviour
{
    [SerializeField]
    GameObject lightObject = null;

    [SerializeField]
    int id = 0;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public int Id { get { return id; } set { id = value; } }

    public void ToggleLight(int value)
    {
        lightObject.SetActive(id == value);
    }
}

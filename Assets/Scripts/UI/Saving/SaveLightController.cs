using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLightController : MonoBehaviour
{
    [SerializeField]
    SavePageIdPool pool;

    [SerializeField]
    GameEventInt menuNumPages;

    [SerializeField]
    GameEventInt currentIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetNumPages()
    {
        pool.DisableAll();
        for (int i = 0; i < menuNumPages.IntValue; i++)
        {
            var light = pool.GetObject();
            light.Id = i;
            light.ToggleLight(currentIndex.IntValue);
            light.gameObject.SetActive(true);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    [SerializeField]
    GameObject shopCanvas = null;

    [SerializeField]
    GameEvent onShopOpened = null;

    public bool CanInteract { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        shopCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanInteract && !shopCanvas.activeInHierarchy && Input.GetButton("OpenUI"))
        {
            onShopOpened.Invoke();
            shopCanvas.SetActive(true);
        }
    }
}

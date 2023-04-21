using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralMenu : MonoBehaviour
{
    public Shop shop;
    public Cash cashMyState;
    public Button opennedShop, oppenedCash;

    private void Start()
    {
        opennedShop.onClick.AddListener(() => shop.gameObject.SetActive(true));
        oppenedCash.onClick.AddListener(() => cashMyState.gameObject.SetActive(true));
    }
}

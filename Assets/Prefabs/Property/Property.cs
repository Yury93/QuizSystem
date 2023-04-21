using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TypeProperty { wife, car, home, company, city, air }
public class Property : MonoBehaviour
{
    public TypeProperty type;
    public int id;
    public TextMeshProUGUI nameText;
    public int price;
    public Button Button;
    public Action<Property> onClickAction;
    //private string nameStr;
    private void Start()
    {
        Button.onClick.AddListener(onClick);
        //nameStr = nameText.text;
    }

    private void onClick()
    {
        onClickAction?.Invoke(this);
    }

    private void OnEnable()
    {
        //nameText.text = nameStr + " " + price + "$";
        
    }
}

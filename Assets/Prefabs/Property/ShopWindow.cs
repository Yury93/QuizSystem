using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    public int score;
    public const string SCORE = "SCORE";
    [Header("readonly")] //с их помощью не сохраняем здесь!
    public  string carId = "carid";
    public string wifeId = "wifeid";
    public  string cityId = "cityid";
    public  string airId = "airid";
    public  string companyId = "companyid";
    public  string houseId = "houseid";
    [Header("readonly")]
    public string savePlayerPrefs;// а здесь сохраняем
    public List<Property> properties;
    public Button buyButton;
    public TextMeshProUGUI scoreText, priceText;

    public Property selectedProperty;

    public void Init()
    {
        properties.ForEach(p => p.onClickAction += OnClickProperty);
        score = PlayerPrefs.GetInt(SCORE);
        scoreText.text = score + "$";
        priceText.text = 0 + "$";
        buyButton.onClick.AddListener(Buy);
    }
    public void Open()
    {
        score = PlayerPrefs.GetInt(SCORE);
        scoreText.text = score + "$";
        gameObject.SetActive(true);

    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Buy()
    {
        if (this.selectedProperty != null)
        {
            PlayerPrefs.SetInt(savePlayerPrefs, selectedProperty.id);
            priceText.text = "Приобретено";
            score -= selectedProperty.price;
            PlayerPrefs.SetInt(SCORE, score);
            scoreText.text = score + "$";
            this.selectedProperty = null;
        }

    }

    private void OnClickProperty(Property property)
    {
        score = PlayerPrefs.GetInt(SCORE);
        if (score < property.price)
        {
            buyButton.interactable = false;
            this.selectedProperty = null;
        }
        else
        {
            buyButton.interactable = true;
           this. selectedProperty = property;
            //score -= property.price;
            //        PlayerPrefs.SetInt(SCORE,score);
            //scoreText.text = score + "$";
            priceText.text = property.price + "$";
        }
    }
}

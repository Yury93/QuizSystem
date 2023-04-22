using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cash : MonoBehaviour
{
    public int score;
    public const string SCORE = "SCORE";

    public const string carId = "carid";
    public const string wifeId = "wifeid";
    public const string cityId = "cityid";
    public const string airId = "airid";
    public const string companyId = "companyid";
    public const string houseId = "houseid";

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Property carText,wifeText,cityText, airText,companyText,houseText;
    [SerializeField] private Button closeButton;
    private void Start()
    {
        closeButton.onClick.AddListener(Close);
    }

    private void Close()
    {
        gameObject.SetActive(false);
        SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        score = PlayerPrefs.GetInt(SCORE);


        scoreText.text = score + "$";
        Debug.Log(Shop.instance);
        var car = Shop.instance.Properties.Where(c => c.type == TypeProperty.car).First(c => c.id == PlayerPrefs.GetInt(carId));
        var wife = Shop.instance.Properties.Where(c => c.type == TypeProperty.wife).First(c => c.id == PlayerPrefs.GetInt(wifeId));
        var city = Shop.instance.Properties.Where(c => c.type == TypeProperty.city).First(c => c.id == PlayerPrefs.GetInt(cityId));
        var air = Shop.instance.Properties.Where(c => c.type == TypeProperty.air).First(c => c.id == PlayerPrefs.GetInt(airId));
        var company = Shop.instance.Properties.Where(c => c.type == TypeProperty.company).First(c => c.id == PlayerPrefs.GetInt(companyId));
        var house = Shop.instance.Properties.Where(c => c.type == TypeProperty.home).First(c => c.id == PlayerPrefs.GetInt(houseId));

        carText.nameText.text = car.nameText.text;
        wifeText.nameText.text = wife.nameText.text;
        cityText.nameText.text = city.nameText.text;
        airText.nameText.text = air.nameText.text;
        companyText.nameText.text = company.nameText.text;
        houseText.nameText.text = house.nameText.text;
    }
}

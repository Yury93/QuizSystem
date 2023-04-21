using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

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
    
    private void OnEnable()
    {
        score = PlayerPrefs.GetInt(SCORE);


        scoreText.text = score + "$";
        var car = Shop.instance.Properties.Where(c => c.type == TypeProperty.car).First(c => c.id == PlayerPrefs.GetInt(carId,0));
        var wife = Shop.instance.Properties.Where(c => c.type == TypeProperty.wife).First(c => c.id == PlayerPrefs.GetInt(wifeId,0));
        var city = Shop.instance.Properties.Where(c => c.type == TypeProperty.city).First(c => c.id == PlayerPrefs.GetInt(cityId,0));
        var air = Shop.instance.Properties.Where(c => c.type == TypeProperty.air).First(c => c.id == PlayerPrefs.GetInt(airId,0));
        var company = Shop.instance.Properties.Where(c => c.type == TypeProperty.company).First(c => c.id == PlayerPrefs.GetInt(companyId,0));
        var house = Shop.instance.Properties.Where(c => c.type == TypeProperty.home).First(c => c.id == PlayerPrefs.GetInt(houseId,0));

        carText.nameText.text = car.nameText.text;
        wifeText.nameText.text = wife.nameText.text;
        cityText.nameText.text = city.nameText.text;
        airText.nameText.text = air.nameText.text;
        companyText.nameText.text = company.nameText.text;
        houseText.nameText.text = house.nameText.text;
    }
}

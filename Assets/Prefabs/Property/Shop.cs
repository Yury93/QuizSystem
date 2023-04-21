using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : SingletonBase<Shop>
{
    public List<Property> Properties;
    public ShopWindow wifeWindow,carWindow,airWindow,homeWindow,companyWindow,cityWindow;
    public Button wifeButton, carButton, airButton, homeButton, companyButton, cityButton;

    private void Start()
    {
        wifeWindow.Init();
        carWindow.Init();
        airWindow.Init();
        homeWindow.Init();
        companyWindow.Init();
        cityWindow.Init();

        wifeButton.onClick.AddListener(() => wifeWindow.Open());
        carButton.onClick.AddListener(() => carWindow.Open());
        airButton.onClick.AddListener(() => airWindow.Open());
        homeButton.onClick.AddListener(() => homeWindow.Open());
        companyButton.onClick.AddListener(() => companyWindow.Open());
        cityButton.onClick.AddListener(() => cityWindow.Open());

        Properties.AddRange(wifeWindow.properties);
        Properties.AddRange(carWindow.properties);
        Properties.AddRange(airWindow.properties);
        Properties.AddRange(homeWindow.properties);
        Properties.AddRange(companyWindow.properties);
        Properties.AddRange(cityWindow.properties);
    }

}

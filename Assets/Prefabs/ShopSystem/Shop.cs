using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<Property> Properties;
    public ShopWindow wifeWindow, carWindow, airWindow, homeWindow, companyWindow, cityWindow;
    public Button wifeButton, carButton, airButton, homeButton, companyButton, cityButton, closeButton;
    public static Shop instance;

    public void Init()
    {
        instance = this;
        wifeWindow.Init();
        carWindow.Init();
        airWindow.Init();
        homeWindow.Init();
        companyWindow.Init();
        cityWindow.Init();

        wifeButton.onClick.AddListener(() =>
        {
            SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
            wifeWindow.Open();

        });
        carButton.onClick.AddListener(() => 
        {
            SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
            carWindow.Open();

        });
        airButton.onClick.AddListener(() =>
        {
            SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
            airWindow.Open();

        });
        homeButton.onClick.AddListener(() =>
        {
            SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
            homeWindow.Open();

        });
        companyButton.onClick.AddListener(() =>
        {
            SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
            companyWindow.Open();

        });
        cityButton.onClick.AddListener(() => 
        {
            SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
            cityWindow.Open();

        });

        Properties = new List<Property>();
        Properties.AddRange(wifeWindow.properties);
        Properties.AddRange(carWindow.properties);
        Properties.AddRange(airWindow.properties);
        Properties.AddRange(homeWindow.properties);
        Properties.AddRange(companyWindow.properties);
        Properties.AddRange(cityWindow.properties);
        closeButton.onClick.AddListener(Close);
    } 

    private void Close()
    {
        SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
        gameObject.SetActive(false);
    }
}

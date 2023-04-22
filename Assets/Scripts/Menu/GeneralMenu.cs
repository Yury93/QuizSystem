using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralMenu : MonoBehaviour
{
    public Shop shop;
    public Cash cashMyState;
    public Button opennedShop, oppenedCash,startGame;
    public SoundSystem soundSystem;
    public Yandex yandex;
    private void Awake()
    {
        yandex.Init();
        soundSystem.Init();
    }

    private void Start()
    {
        opennedShop.onClick.AddListener(() =>
        {
            SoundSystem.instance.CreateSound(
            SoundSystem.instance.soundLibrary.clickButton);
            shop.gameObject.SetActive(true); 
        });
        oppenedCash.onClick.AddListener(() =>
        {
            SoundSystem.instance.CreateSound(
                SoundSystem.instance.soundLibrary.clickButton);
            cashMyState.Open();
        });
        startGame.onClick.AddListener(() =>
        {
            SoundSystem.instance.CreateSound(SoundSystem.instance.soundLibrary.clickButton);
            SceneLoader.LoadGame();
        });
       shop.Init();
    }
}

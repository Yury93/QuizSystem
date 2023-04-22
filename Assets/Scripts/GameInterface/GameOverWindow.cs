using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private Button continueButton, addRewardButton;
    [SerializeField] private TextMeshProUGUI scoreByThisGameText;
    private int scoreByThisGame;
    private int startScore;
    private int endScore;
    public void Init()
    {
        startScore = PlayerPrefs.GetInt("SCORE");
        continueButton.onClick.AddListener(OnClickContinue);
        addRewardButton.onClick.AddListener(ShowAdvReward);
        Yandex.instance.OnShowAdvReward += NowShowAdv;
        addRewardButton.onClick.AddListener(Yandex.instance.ShowAdvButton);
        Yandex.instance.AdvButton = addRewardButton;
    }

    private void NowShowAdv(bool wasShownAdv)
    {
        if (wasShownAdv == true)
        {
            SoundSystem.instance.IsADV = true;
            SoundSystem.instance.SetActiveSound(false);
        }
        else
        {
            SoundSystem.instance.IsADV = false;
            SoundSystem.instance.SetActiveSound(true);

        }
    }

    private void ShowAdvReward()
    {
        var score = PlayerPrefs.GetInt("SCORE") + (scoreByThisGame *2);
        PlayerPrefs.SetInt("SCORE", score);
        scoreByThisGameText.text = $"Вы заработали {scoreByThisGame * 2}$";
        addRewardButton.gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        endScore = PlayerPrefs.GetInt("SCORE");
        SoundSystem.instance.CreateSound(SoundSystem.instance.soundLibrary.lose,0.1f,0.25f);
        if (startScore == endScore)
        {
            scoreByThisGame = 0;
            addRewardButton.gameObject.SetActive(false);
        }
        else
        {
            scoreByThisGame = endScore - startScore;
        }

        scoreByThisGameText.text = $"Вы заработали {scoreByThisGame}$";
    }
    public void OnClickContinue()
    {
        SceneLoader.LoadMenu();
    }
    
}

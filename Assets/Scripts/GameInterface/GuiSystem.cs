using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GuiSystem : MonoBehaviour
{
    [SerializeField] private int currentScore;
    [SerializeField] private float secondTime;
    [SerializeField] private int lives;

    [SerializeField] private TextMeshProUGUI hpText, scoreText, timerText;

    private Coroutine CoroutineTimer;
    private float startTimer;
    private QuizSystem quizSystem;

    private const string SCORE = "SCORE";
    private int bonusScore;


    public void Init()
    {
        quizSystem = CoreEnivroment.instance.QuizSystem;
        quizSystem.OnPlayerReplied += OnPlayerReplied;
        startTimer = secondTime;
        ///написать сохранение 
        currentScore = PlayerPrefs.GetInt(SCORE);


        hpText.text = lives.ToString();
        scoreText.text = currentScore + "$";
        timerText.text = secondTime.ToString() + " сек.";
        bonusScore = 0;
    }

    private void OnPlayerReplied(StateQuiz stateQuiz)
    {
      if(stateQuiz == StateQuiz.correctAnswer)
        {
            OnCorrectAnswer();
        }
      if(stateQuiz == StateQuiz.nonCorrectAnswer)
        {
            OnNonCorrectAnswer();
        }
      if(stateQuiz == StateQuiz.quizProcess)
        {
            OnQuizProcess();
        }
    }

    private void OnQuizProcess()
    {
       
        if (CoroutineTimer != null) StopCoroutine(CoroutineTimer);

        secondTime = startTimer;
        timerText.text = secondTime.ToString() + " сек.";
        CoroutineTimer = StartCoroutine(CorTimer());
  
    }

    private void OnNonCorrectAnswer()
    {
        if (CoroutineTimer != null) StopCoroutine(CoroutineTimer);
        timerText.text = secondTime.ToString() + " сек."; ;

        if (lives > 1) 
        {
            lives -= 1;
            hpText.text = lives.ToString();
            Debug.Log(" minus hp " + lives);
        }
        else
        {
            CoreEnivroment.instance.GameOverWindow.Open();
         
        }
    }

    private void OnCorrectAnswer()
    {
        if (CoroutineTimer != null) StopCoroutine(CoroutineTimer);
        timerText.text = secondTime.ToString() + " сек."; ;

        if (bonusScore != 0)
        {
            currentScore += bonusScore;
            bonusScore += 1;
        }
        else
        {
            currentScore += 1;
        }
        Debug.Log("currentScore " + currentScore);
        PlayerPrefs.SetInt(SCORE, currentScore);
        scoreText.text = currentScore + "$";
    }

    IEnumerator CorTimer()
    {
        while (secondTime >= 0)
        {
            yield return new WaitForSeconds(1);
            secondTime -= 1;
            timerText.text = secondTime.ToString() + " сек.";
        }
        secondTime = startTimer;
        quizSystem.AnswerButtons.First(b => b).Button.onClick.Invoke();
    }
}

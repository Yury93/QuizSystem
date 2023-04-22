using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
public enum StateQuiz { correctAnswer, nonCorrectAnswer, quizProcess }
public class QuizSystem : MonoBehaviour
{
    [Serializable]
    public class Question
    {
        [TextArea(2, 5)]
        public string InputQuest;
        [TextArea(2, 4)]
        public List<string> InputAnswer = new List<string>(3);
    }
    [SerializeField] private List<Question> questions;
    [SerializeField] private TextMeshProUGUI quests;
    [SerializeField] private List<AnswerButton> answersButton;
    public List<AnswerButton> AnswerButtons => answersButton;


    private int rnd;
    private string rightAnswer;
    private AnswerButton buttonAnswer;
    private Coroutine CoroutineRightAnswer;

    public event Action<StateQuiz> OnPlayerReplied;
    public void Init()
    {
        answersButton.ForEach(a => a.Init());
        QuestionGenerate();
    }
    public void OnSelectAnswer()
    {
        ClickAnswer();
        answersButton.ForEach(b => b.Button.interactable = false);

        StartCoroutine(CorDelay());

        IEnumerator CorDelay()
        {
            yield return new WaitForSecondsRealtime(2f);
            OnPlayerReplied?.Invoke(StateQuiz.quizProcess);
            QuestionGenerate();
            quests.enabled = true;
            answersButton.ForEach(b => b.Button.image.color = Color.white);
            yield return new WaitForSecondsRealtime(0.5f);
            answersButton.ForEach(b => b.Button.interactable = true);
        }
    }
    //по индексу нулевой ансвер всегда верный 
    private void QuestionGenerate()
    {
        if (CoroutineRightAnswer != null)
            StopCoroutine(CoroutineRightAnswer);

        answersButton.ForEach(b => b.SetCheckerRightAnswer(false));

        if (questions.Count != 0)
        {
            rnd = UnityEngine.Random.Range(0, questions.Count);
            quests.text = questions[rnd].InputQuest;

            rightAnswer = questions[rnd].InputAnswer[0];

            for (int i = 0; i < answersButton.Count; i++)
            {
                var r = UnityEngine.Random.Range(0, questions[rnd].InputAnswer.Count);
                answersButton[i].TextButton.text = questions[rnd].InputAnswer[r];
                if (answersButton[i].TextButton.text == rightAnswer)
                {
                    answersButton[i].SetCheckerRightAnswer(true);
                }
                questions[rnd].InputAnswer.RemoveAt(r);
            }
            questions.RemoveAt(rnd);

        }
        else 
        {

            CoreEnivroment.instance.GameOverWindow.Open();
                return;
        
        }
    }

    public void ClickAnswer()
    {
        var text = buttonAnswer.TextButton.text;

        if (rightAnswer == text)
        {
            OnPlayerReplied?.Invoke(StateQuiz.correctAnswer);
            buttonAnswer.Button.image.color = Color.green;
        }
        else
        {
            OnPlayerReplied?.Invoke(StateQuiz.nonCorrectAnswer);
            buttonAnswer.Button.image.color = Color.red;

            ShowRightAnswer();
        }
        SoundSystem.instance.CreateSound(SoundSystem.instance.soundLibrary.clickButton);
    }

    private void ShowRightAnswer()
    {
        var b = answersButton.First(a => a.IsRightAnswer);
        CoroutineRightAnswer = StartCoroutine(CorShowRightAnswer(b));
    }
    IEnumerator CorShowRightAnswer(AnswerButton answerButton)
    {
        //answerButton.Button.image.color = Color.green;

        answerButton.Button.image.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        answerButton.Button.image.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        answerButton.Button.image.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        answerButton.Button.image.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        answerButton.Button.image.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        answerButton.Button.image.color = Color.green;
        yield return new WaitForSeconds(0.2f);

    } 

    public void SetButtonAnswer(AnswerButton buttonAnswer)
    {
        this.buttonAnswer = buttonAnswer;
    }
}

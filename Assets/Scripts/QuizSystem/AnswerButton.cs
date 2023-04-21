using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textButton;
    public bool IsRightAnswer { get; private set; }
    public Button Button => button;
    public TextMeshProUGUI TextButton => textButton;
    public void Init()
    {
        button.onClick.AddListener(GetTextButton);
        button.onClick.AddListener(CoreEnivroment.instance.QuizSystem.OnSelectAnswer);
    }
    public void SetCheckerRightAnswer(bool rightAnswer)
    {
        IsRightAnswer = rightAnswer;
    }
    public void GetTextButton()
    {
       CoreEnivroment.instance.QuizSystem.SetButtonAnswer(this);
    }
}

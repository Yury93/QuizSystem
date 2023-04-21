using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreEnivroment : SingletonBase<CoreEnivroment>
{
    [SerializeField] private QuizSystem quizSystem;
    [SerializeField] private GuiSystem guiSystem;
    public QuizSystem QuizSystem => quizSystem;
   
    
    public void Start()
    {
        quizSystem.Init();
        guiSystem.Init();
    }
}

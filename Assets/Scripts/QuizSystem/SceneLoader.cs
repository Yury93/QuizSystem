using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    public static void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public static void RestartScene()
    {
      
    }
    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase <T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    public bool IsNotDestroy;
    void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(this);
        }
        if(IsNotDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

 
}

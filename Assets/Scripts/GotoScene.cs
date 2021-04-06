using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{
    private float timer;
    private float timerRef;

    private bool startTimer;
    
    [SerializeField]
    private string sceneName;
    //private string scene2;

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            
            if (timer >= 2.0f)
            {
                SceneManager.LoadScene(sceneName);
            }
            //Debug.Log("Timer is " + timer);
        }
        
    }

    public void NextScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        //Debug.Log(scene2);
    }

    public void EnableDelay()
    {
        startTimer = true;
    }
    
    /*public void DelayGotoScene(string newScene)
    {
        if (timer >= 2.5f)
        {
            NextScene(newScene);
            Debug.Log("Method Timer = " + timer);
        }
    }*/

    public void DisableDelay()
    {
        timer = 0.0f;
        startTimer = false;
    }
}

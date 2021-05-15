using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopVideo : MonoBehaviour
{
    private float timer;

    private bool startTimer;
    
    [SerializeField]
    private string sceneName;

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            
            if (timer >= 2.0f)
            {
                LoadScenes.scenes = new ArrayList();
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void NextScene(string sceneName)
    {
        LoadScenes.scenes = new ArrayList();
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void EnableDelay()
    {
        startTimer = true;
    }
    
    public void DelayGotoScene(string newScene)
    {
        if (timer >= 2.5f)
        {
            NextScene(newScene);
        }
    }

    public void DisableDelay()
    {
        timer = 0.0f;
        startTimer = false;
    }
}

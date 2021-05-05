using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTour : MonoBehaviour
{
    private float timer;

    private bool startTimer;
    public static Tour activeTour;

    public String tour;

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            
            if (timer >= 2.0f)
            {
                activeTour = MenuGetData.tours[int.Parse(tour)] as Tour;
                SceneManager.LoadScene("Tour");
            }
        }
        
    }

    public void EnableDelay()
    {
        startTimer = true;
    }

    public void DisableDelay()
    {
        timer = 0.0f;
        startTimer = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButtonCardboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // close icon pressed, place appropriate code here
            SceneManager.LoadSceneAsync("Instructions");
            EnableVRSettings.SwitchToNOVR();
        }
    }
}

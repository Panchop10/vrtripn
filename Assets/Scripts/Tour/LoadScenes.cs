using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScenes : MonoBehaviour
{
    public static ArrayList scenes;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Debug.Log("******************* 1");
            FirebaseGetScenes.getScenes(this);
            Debug.Log("******************* 5");
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

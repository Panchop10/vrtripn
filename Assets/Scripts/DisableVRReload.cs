using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVRReload : MonoBehaviour
{
    public static bool disabled;
    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableReload()
    {
        disabled = true;
    }
}

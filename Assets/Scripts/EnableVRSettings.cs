using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR;

public class EnableVRSettings : MonoBehaviour
{
    //public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (!DisableVRReload.disabled)
        {
            StartCoroutine(SwitchToVR());
        }
        //videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(SwitchToVR());

    }

    // Call via `StartCoroutine(SwitchToVR())` from your code. Or, use
    // `yield SwitchToVR()` if calling from inside another coroutine.
    IEnumerator SwitchToVR() {
        //https: //github.com/googlevr/gvr-unity-sdk/issues/826
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        // Google original, makes you specify
        //string desiredDevice = "daydream"; // Or "cardboard".
        //XRSettings.LoadDeviceByName(desiredDevice);
        // this is slightly better;
        //string[] DaydreamDevices = new string[] { "daydream", "cardboard" };
        //XRSettings.LoadDeviceByName(DaydreamDevices);
        if (UnityEngine.XR.XRSettings.loadedDeviceName != "cardboard") {
            //Debug.Log("cardboard");
            //Debug.Log(UnityEngine.XR.XRSettings.loadedDeviceName);
            XRSettings.LoadDeviceByName("cardboard");
            //XRSettings.LoadDeviceByName("");

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;

            // Now it's ok to enable VR mode.
            XRSettings.enabled = true;
        }
    }

    public static void SwitchToNOVR()
    {
        //https: //github.com/googlevr/gvr-unity-sdk/issues/826
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        // Google original, makes you specify
        //string desiredDevice = "daydream"; // Or "cardboard".
        //XRSettings.LoadDeviceByName(desiredDevice);
        // this is slightly better;
        //string[] DaydreamDevices = new string[] { "daydream", "cardboard" };
        //XRSettings.LoadDeviceByName(DaydreamDevices);
        if (UnityEngine.XR.XRSettings.loadedDeviceName == "cardboard")
        {
            XRSettings.LoadDeviceByName("");

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            //yield return null;

            // Now it's ok to enable VR mode.
            XRSettings.enabled = false;
        }
    }

}

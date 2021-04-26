using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuGetData : MonoBehaviour
{
    public static ArrayList tours = new ArrayList();
    public bool updated = true;


    void Start()
    {
        try
        {
            FirebaseGetTours.getTours(this);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tours.Count != 0 && updated == false) {
            StartCoroutine(loadData());
            updated = true;
        }
    }

    IEnumerator loadData() {
        Tour tour1 = tours[0] as Tour;
        Tour tour2 = tours[1] as Tour;
        Tour tour3 = tours[2] as Tour;

        // load images
        WWW wwwOne = new WWW(tour1.image_link);
        while (!wwwOne.isDone)
            yield return null;
        WWW wwwTwo = new WWW(tour2.image_link);
        while (!wwwTwo.isDone)
            yield return null;
        WWW wwwThree = new WWW(tour3.image_link);
        while (!wwwThree.isDone)
            yield return null;

        // update menu objects
        GameObject rawImage1 = GameObject.Find("RawImageOne");
        rawImage1.GetComponent<RawImage>().texture = wwwOne.texture;
        GameObject text1 = GameObject.Find("TextOne");
        text1.GetComponent<TMP_Text>().text = tour1.title;

        GameObject rawImage2 = GameObject.Find("RawImageTwo");
        rawImage2.GetComponent<RawImage>().texture = wwwTwo.texture;
        GameObject text2 = GameObject.Find("TextTwo");
        text2.GetComponent<TMP_Text>().text = tour2.title;

        GameObject rawImage3 = GameObject.Find("RawImageThree");
        rawImage3.GetComponent<RawImage>().texture = wwwThree.texture;
        GameObject text3 = GameObject.Find("TextThree");
        text3.GetComponent<TMP_Text>().text = tour3.title;
    }
}

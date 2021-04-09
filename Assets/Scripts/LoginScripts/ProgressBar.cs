using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        loadingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Activate Progress Bar
    public void setActive(bool activate) {
        if (activate)
        {
            loadingPanel.SetActive(true);
            loadingBar.value = 100;
        }
        else {
            loadingPanel.SetActive(false);
        }
    }
}

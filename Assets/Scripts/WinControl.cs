using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinControl : MonoBehaviour
{

    //Will hold the amount of collectables gotten
    private int collectables = 0;

    // UI object to display winning text.
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    public void updateCollectables()
    {
        collectables = collectables + 1;

        if(collectables == 3){
            Time.timeScale = 0f;
            winTextObject.SetActive(true);
        }
    }
}

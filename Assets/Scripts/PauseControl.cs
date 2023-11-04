using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseControl : MonoBehaviour
{
    //Code was gotten from https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/

    //Will keep track of whether the game is paused or not
    public static bool gameIsPaused;

    //Will display the text used for pausing the game
    public GameObject pauseText;

    void Start()
    {
        // Initially set the win text to be inactive.
        pauseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    //Will pause and unpause the game depending on whether the game is currently paused or not
    void PauseGame(){
        if(gameIsPaused)
        {
            //Pauses the game
            Time.timeScale = 0f;
            pauseText.SetActive(true);
        }
        else 
        {
            //Unpauses the game
            Time.timeScale = 1;
            pauseText.SetActive(false);
        }
    }
}

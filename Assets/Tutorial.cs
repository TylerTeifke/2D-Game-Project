using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            } 
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }
        
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.D))
            {

            }
        }
    }
}

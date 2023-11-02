using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code gotten from https://www.youtube.com/watch?v=dwcT-Dch0bA

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float speed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool dash = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if(Input.GetButtonDown("Jump")){
            jump = true;
        }

        if(Input.GetButtonDown("Dash")){
            dash = true;
        }
    }

    void FixedUpdate(){

        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump, dash);
        jump = false;
        dash = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code gotten from https://www.youtube.com/watch?v=dwcT-Dch0bA

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float speed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool dash = false;
    bool upwardSlash = false;
    bool downwardSlash = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if(Input.GetButtonDown("Dash")){
            dash = true;
        }

        if(Input.GetButtonDown("Upward")){
            upwardSlash = true;
        }

        if(Input.GetButtonDown("Downward")){
            downwardSlash = true;
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate(){

        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump, dash, upwardSlash, downwardSlash);
        jump = false;
        dash = false;
        upwardSlash = false;
        downwardSlash = false;
    }
}

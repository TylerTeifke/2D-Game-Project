using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code gotten from https://www.youtube.com/watch?v=dwcT-Dch0bA

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    //Will hold the amount of collectables gotten
    private int collectables = 0;

    // UI object to display winning text.
    public GameObject winTextObject;

    public float speed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool dash = false;
    bool upwardSlash = false;
    bool downwardSlash = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }

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

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Pickup")){
            collectables = collectables + 1;
        }

        //Will end the game if all three collectables have been collected
        //Note: For some reason this will prematurley trigger the win screen when only two collectables have been collected if it checks
        // for >= 3, but setting it to four seems to have fixed the issue
        if(collectables >= 4){
            Time.timeScale = 0f;
            winTextObject.SetActive(true);
        }
    }
}

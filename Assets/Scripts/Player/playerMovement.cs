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

    //UI objects for displaying tutorials
    public GameObject dashTutorial;
    public GameObject upwardTutorial;
    public GameObject downwardTutorial;

    public float speed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool dash = false;
    bool upwardSlash = false;
    bool downwardSlash = false;

    //Will allow the player to input special moves when an item is collected
    bool canDash = false;
    bool canUpward = false;
    bool canDownward = false;

    //Will tell if a tutorial is active
    bool tutorialActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);

        dashTutorial.SetActive(false);
        upwardTutorial.SetActive(false);
        downwardTutorial.SetActive(false);
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

        if(Input.GetButtonDown("Dash") && canDash){
            dash = true;
        }

        if(Input.GetButtonDown("Upward") && canUpward){
            upwardSlash = true;
        }

        if(Input.GetButtonDown("Downward") && canDownward){
            downwardSlash = true;
        }

        if (Input.GetKeyDown(KeyCode.T) && tutorialActive){
            dashTutorial.SetActive(false);
            upwardTutorial.SetActive(false);
            downwardTutorial.SetActive(false);
            tutorialActive = false;
            Time.timeScale = 1f;
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
        //When a specific pick up has been collected, the power up tied to that pick up will be activated
        //When a power up is collected, a tutorial will appear on screen that tells the player how to use it
        if(other.CompareTag("Dash")){
            canDash = true;
            Time.timeScale = 0f;
            tutorialActive = true;
            dashTutorial.SetActive(true);
        }

        if(other.CompareTag("Upward")){
            canUpward = true;
            Time.timeScale = 0f;
            tutorialActive = true;
            upwardTutorial.SetActive(true);
        }

        if(other.CompareTag("Downward")){
            canDownward = true;
            Time.timeScale = 0f;
            tutorialActive = true;
            downwardTutorial.SetActive(true);
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

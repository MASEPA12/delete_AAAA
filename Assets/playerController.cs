using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody rb;
    public float walkingForce = 0.5f;
   
    public float jumpingForce = 0.2f;
    //private float gravityModifier = 1.5f;

    //private bool isJumping;
    public Animator animator;

    private float speed = 2f;
    //private float turnSpeed = 100f;
    private float horizontalInput;
    private float verticalInput;

    public Vector3 movement; 


    void Start()
    {
        animator = GetComponent<Animator>();
        //Physics.gravity *= gravityModifier;
        rb = GetComponent<Rigidbody>();
        //isJumping = false;

    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical"); //movement front/back 
        horizontalInput = Input.GetAxis("Horizontal"); //side movement

        movement = new Vector3(horizontalInput,0,verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);

        //PlayerMovement(movement);

        /*verticalInput = Input.GetAxis("Vertical"); //movement front/back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * rotationInput); //rotation*/

        //CROUCH
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetBool("isSteady", false); //ja no esta`dret  
            animator.SetBool("isRunning", false); //ja no esta`dret  //pensar a canviar ses velocitats quan va cap enrrere i acotada (speed/2 quan is steady true o algo així)
        }
        if (!Input.GetKey(KeyCode.R))
        {
            animator.SetBool("isSteady", true); //si no pitj, està dret
            //rb.AddForce(Vector3.forward * walkingForce, ForceMode.Force);
        }

        //JUMPING
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }

        //RUNNING
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //RUNNING BCK
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isRunningBck", true);
        }
        else
        {
            animator.SetBool("isRunningBck", false);
        }

        //PATADA
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("isPegando", true);
                
        }
        if (!Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("isPegando", false);
        }

        //SHOOTING
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("isShooting", true);
        }
        if (!Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("isShooting", false);
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void PlayerMovement(Vector3 direction)
    {
        rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}



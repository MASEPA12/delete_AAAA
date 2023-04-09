using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody rb;
    public float walkingForce = 0.5f;
   
    public float jumpingForce = 0.2f;
    private float gravityModifier = 1.5f;

    //private bool isJumping;
    public Animator animator;

    private float speed = 2f;
    private float turnSpeed = 100f;
    private float rotationInput;
    private float verticalInput;


    void Start()
    {
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        rb = GetComponent<Rigidbody>();
        //isJumping = false;

    }

    private void Update()
    {

        verticalInput = Input.GetAxis("Vertical"); //movement front/back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);


        rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * rotationInput); //rotation

         
        if(Input.GetKeyDown(KeyCode.R) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))) //si camin front/back and vaig acotda
        {
            transform.Translate(Vector3.forward * speed/2 * Time.deltaTime * verticalInput);
            animator.SetBool("isMovingCrouched", true);
        }


        //CROUCH
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetBool("isSteady", false); //ja no esta`dret  
            animator.SetBool("isRunning", false); //ja no esta`dret  
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
}



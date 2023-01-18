using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
   //Public Variables 
   public CharacterController controller;
   public CharacterController playerHeight;
   //for speed de bugging - public float speed = 12f;
   public float gravity = -65f;
   public float jumpHeight = 3f;
   public float normalHeight, crouchHeight;
   
   //Public Variables for Ground check 
   public Transform groundCheck;
   public float groundDistance = 0.4f;
   public LayerMask groundMask;
    
   //Bool and velocity Variables
   Vector3 velocity;
   bool isGrounded;
 
 
   void Update()
   {
        //Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        //Player grounded velocity / limiter
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movement on the axis planes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
 
        Vector3 move = transform.right * x + transform.forward * z;
        
        //player speed
        float speed = 12f;
       
        //Crouch code
        if(Input.GetKey(KeyCode.LeftControl))
        {
            speed *= 0.5f;
            playerHeight.height = crouchHeight;
        }else{
            playerHeight.height = normalHeight;
        }
 
        //sprint code
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed *=1.5f;
        }
        
        //Shift and crouch check
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 0.5f;
            playerHeight.height = crouchHeight;
        }else{
            playerHeight.height = normalHeight;
        }
        controller.Move(move * speed * Time.deltaTime);

        //jump code
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //equations for jumping 
        velocity.y += gravity * Time.deltaTime;
 
        controller.Move(velocity * Time.deltaTime);
   }
}

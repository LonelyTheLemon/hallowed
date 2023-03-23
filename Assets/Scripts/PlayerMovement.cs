using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
   public CharacterController controller;
   public CharacterController playerHeight;
   //for speed debugging - public float speed = 12f;
   public float gravity = -65f;
   public float jumpHeight = 3f;
   public float normalHeight, crouchHeight;
   
   //Public Variables for Ground check 
   public Transform groundCheck;
   public float groundDistance = 0.4f;
   public LayerMask groundMask;
    
   Vector3 velocity;
   bool isGrounded;
 
 
   void Update()
   {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //Ground Check
 
        
        if(isGrounded && velocity.y < 0) //Player grounded velocity / limiter
        {
            velocity.y = -2f;
        }

        //Movement on the axis planes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
 
        Vector3 move = transform.right * x + transform.forward * z;
        
        
        float speed = 6f; //player speed
       
        
        if(Input.GetKey(KeyCode.LeftControl)) //Crouch code
        {
            speed *= 0.5f;
            playerHeight.height = crouchHeight;
        }else{
            playerHeight.height = normalHeight;
        }
        controller.Move(move * speed * Time.deltaTime);

        
        if(Input.GetKey(KeyCode.LeftShift)) //Sprint code
        {
            speed *=2f;
        }
        controller.Move(move * speed * Time.deltaTime);

        
        if(Input.GetButtonDown("Jump") && isGrounded) //jump code
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        
        velocity.y += gravity * Time.deltaTime; //equations for jumping 
 
        controller.Move(velocity * Time.deltaTime); //movement controller
   }
}

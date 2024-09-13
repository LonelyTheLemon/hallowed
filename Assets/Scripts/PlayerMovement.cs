using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public CharacterController playerHeight;

    public float gravity = -75f;
    public float jumpHeight = 3f;
    public float normalHeight, crouchHeight;

    // Variables for ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public LayerMask Ground; // Layer for first type of ground
    public LayerMask CabinGround; // Layer for second type of ground

    public AudioSource audioSource;  // Reference to the AudioSource component
    public AudioClip Outside;  // Sound for the first layer
    public AudioClip Cabin;  // Sound for the second layer

    public float walkPitch = 1f;   // Normal walking pitch
    public float sprintPitch = 1.5f; // Sprinting pitch

    Vector3 velocity;
    bool isGrounded;

    bool isMoving = false;  // To track if the player is moving
    float currentSpeed = 2.5f;  // Player's current speed

    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Player grounded velocity/limiter
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movement on the axis planes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Check if the player is moving
        isMoving = move.magnitude > 0.1f;

        // Player speed
        currentSpeed = 2.5f;

        // Crouch code
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed *= 1f;
            playerHeight.height = crouchHeight;
        }
        else
        {
            playerHeight.height = normalHeight;
        }

        // Sprint code
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= 3f;
        }

        // Move the player
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Check which layer the player is on and play the corresponding sound
        if (isGrounded && isMoving)
        {
            int layer = GetGroundLayer();
            PlayFootstepSound(layer);
        }
        else
        {
            StopFootstepSound();
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Movement controller
        controller.Move(velocity * Time.deltaTime);
    }

    // Get the layer of the ground the player is standing on
    int GetGroundLayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDistance + 0.1f))
        {
            return hit.collider.gameObject.layer;
        }
        return -1;  // Return -1 if no ground detected
    }

    // Play footstep sound based on the layer and adjust pitch for sprinting
    void PlayFootstepSound(int layer)
    {
        if (!audioSource.isPlaying)
        {
            if (layer == LayerMask.NameToLayer("Ground")) 
            {
                audioSource.clip = Outside;
            }
            else if (layer == LayerMask.NameToLayer("CabinGround")) 
            {
                audioSource.clip = Cabin;
            }

            audioSource.loop = true;  // Loop the sound while moving
            audioSource.Play();
        }

        // Adjust pitch for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            audioSource.pitch = sprintPitch;  // Increase pitch for sprinting
        }
        else
        {
            audioSource.pitch = walkPitch;  // Normal pitch for walking
        }
    }

    
    void StopFootstepSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();  // Pause the sound when the player stops
        }
    }
}

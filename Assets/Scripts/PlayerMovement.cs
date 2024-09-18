using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float gravity = -75f;
    [SerializeField] float normalHeight, crouchHeight;

    // Variables for ground check
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    // [SerializeField] LayerMask Ground; // Layer for first type of ground
    // [SerializeField] LayerMask CabinGround; // Layer for second type of ground

    [SerializeField] AudioSource audioSource;  // Reference to the AudioSource component
    [SerializeField] AudioSource audioBuffer;
    bool audioFlip = false; // used for alternating between original audio source and buffer
    [SerializeField] AudioClip footstepOutside;  // Sound for the first layer
    [SerializeField] AudioClip footstepInside;  // Sound for the second layer
    
    float walkStepInterval = 1f;
    float walkStepProgress = 0;

    Vector3 velocity;
    bool isGrounded;
    int groundLayer;

    bool isMoving = false;  // To track if the player is moving
    bool isSprinting = false;
    float currentSpeed = 2.5f;  // Player's current speed
    float sprintSpeedMultiplier = 3f;

    void Update()
    {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isSprinting = false;

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
        if(Input.GetKey(KeyCode.LeftControl)) {
            controller.height = crouchHeight;
        }
        else {
            controller.height = normalHeight;
        }

        // Sprint code
        if (Input.GetKey(KeyCode.LeftShift)) {
            currentSpeed *= sprintSpeedMultiplier;
            isSprinting = true;
        }

        // Move the player
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Check which layer the player is on and play the corresponding sound
        if (isMoving) {
            groundLayer = GetGroundLayer();
            if(isSprinting) {
                walkStepProgress += Time.deltaTime * sprintSpeedMultiplier;
            }
            else {
                walkStepProgress += Time.deltaTime;
            }
        }
        else {
            // makes the first step come sooner
            walkStepProgress = walkStepInterval / 1.5f;
        }
        
        if(walkStepProgress >= walkStepInterval) {
            PlayFootstepSound();
            walkStepProgress = 0;
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
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, 0.2f))
        {
            return hit.collider.gameObject.layer;
        }
        return -1;  // Return -1 if no ground detected
    }
    
    void PlayFootstepSound() {
        if (groundLayer == LayerMask.NameToLayer("Ground")) {
            audioSource.clip = footstepOutside;
            audioBuffer.clip = footstepOutside;
        }
        else if (groundLayer == LayerMask.NameToLayer("CabinGround")) {
            audioSource.clip = footstepInside;
            audioBuffer.clip = footstepInside;
        }
        
        if(audioFlip) {
            audioSource.Play();
            audioFlip = !audioFlip;
        }
        else {
            audioBuffer.Play();
            audioFlip = !audioFlip;
        }
    }
}

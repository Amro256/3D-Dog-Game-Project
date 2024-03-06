using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horzDirection;
    float vertDirection;
    public float movSpeed = 5f; //The speed of the player. The higher the number the faster the player will move
    public float sprintSpeed = 12f; //Hard coded value. 
    public float lastSpeed;
    public float jumpForce = 5f;
    Rigidbody rb; //Refernece to player rigidbody
    public bool isGrounded = true; //Bool to check if player is grounded 
    StaminaBar stam; //Reference to stamina bar Script
    private Animator ani;
    public new Transform camera; //Allows the main camera to be dropped in the inspector, but will remain private
    public ParticleSystem wallDestroy;

    //Audio 
    [SerializeField] private AudioSource wallSound;
    [SerializeField] private AudioSource runningSound;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource runSound;
    [SerializeField] private AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stam = GetComponent<StaminaBar>();
        ani = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift) && stam.stamina >= 0f ) //if the player presses and holds on the left shift key the speed with  multiply by 1.5
        { 
            runSound.enabled = true;
            movSpeed = sprintSpeed;
            stam.DecreaseStam(); //Calls the decrease stamina method from the stamina bar script
            ani.SetBool("IsRunning", true); //Running animation plays
            stam.stamBar.value = stam.stamina;
        }
        else //Once the player lets go of the button the move speed with return to the previous speed set in the inspector
        {
            runSound.enabled = false;
            movSpeed = lastSpeed;
            ani.SetBool("IsRunning", false); //Running animation stops playing
        }

        if(Input.GetKey(KeyCode.P)) //cheat code for the demo showcase if needed 
        {
            stam.stamina = 10;
            stam.stamBar.value = stam.stamina;
        }
    }

     void FixedUpdate()  //Things physics related go in here
    {
        //Player input 
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")).normalized; //Stores user input as a movement vector
        
        //rb.MovePosition(transform.position + movement * Time.deltaTime * movSpeed);

        //Checks if the character is moving or not and transitions between animations
        if(movement.magnitude >= 0.1f)   
        {
            walkSound.enabled = true;
            float moveAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + camera.eulerAngles.y; //Atan2 returns the angle between the X-axis and 2D vector that starts at 0 and terminates at x,y
            //Rad2Deg Converts the angle in Raidans to degress
            rb.transform.rotation = Quaternion.Euler(0f, moveAngle, 0f); //Sets the roation by using Quaternion.Euler that returns the rotation  in the y axis
            Vector3 movDir = Quaternion.Euler(0f, moveAngle, 0f) * Vector3.forward; // Makes the player rotation smooth and not snap in the direction that the player is facing
            rb.MovePosition(transform.position + movDir * movSpeed * Time.deltaTime); //Moves the rigidbody

            //Quaternion Rotation = Quaternion.LookRotation(movement); //Quaternion deals with rotation - .LookRoation creates a roation with a specific forward/upward direction
            //rb.MoveRotation(Rotation); //rb.moveRotation rotates the rb that is in line with the rb settings
            ani.SetBool("IsWalking", true); //Triggers the walking animation
        }
        else
        {
            walkSound.enabled = false;
            ani.SetBool("IsWalking", false); //Animation will be set back to Idle
        }


        //jump
        if(Input.GetButton("Jump") && isGrounded) //if the space bar is placed the player jumps  and checks if the player is grounded 
        {
            jumpSound.Play();
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse); //an upwards forced is being applied to the Player's rb ya xsis. The force mode is set to Impulse as it is instant
            isGrounded = false;  //the checkbox in the inspector will be unticked as the player has jumped 
            ani.SetBool("IsJumping", true);
            walkSound.enabled = false;
        } 
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true; //if the player collides with the ground, the player will be grounded and wont be able to jump again in the air
            ani.SetBool("IsJumping", false);
        }
         if(collision.gameObject.CompareTag("Walls")&& movSpeed == 7.5 && stam.stamina > 2)  //Wall is only destroyed if the player is in the sprint/charge state and if stamina is greater than 2
        {
            wallSound.Play();
            Instantiate(wallDestroy.gameObject, transform.position, transform.rotation);
            //print("Bone Collected");
            Destroy(collision.gameObject);
        }
       else if(collision.gameObject.CompareTag("Walls")&& movSpeed < 7.5)
       {
            print("You must sprint into the wall to destroy it");
       }

    }
    
}


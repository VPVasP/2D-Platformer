using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public LayerMask groundMask; //layermask for the ground
    Animator thisAnimator; //the animator component
    Rigidbody2D rb; //rigibody component
    float inpHor;//horizontal input
    [SerializeField] private float speed = 5f; //speed value
    [SerializeField] private float jumpForce; //jump force value
    [SerializeField] bool isGrounded = false; //isgrounded bool
    [SerializeField] float groundDistance = 0.6f; //the ground distance value
    bool isFacingRight; //bool to check if player is facing right
    void Start()
    {
        thisAnimator = GetComponent<Animator>();//we get the animator component
        rb = GetComponent<Rigidbody2D>(); //we get the rigibody component
        isFacingRight = true; //at the start we need the player to face right
    }

    // Update is called once per frame
    void Update()
    {
        inpHor = Input.GetAxis("Horizontal"); //we get the axis horizontal
        isGrounded = isGroundedBool(); //check if the player is grounded
        //if we press space and we are grounded we jump
        if (Input.GetKeyDown(KeyCode.Space) && isGroundedBool())
        {
            Jump();
        }
        //flip the characters direction if he is moving in the opposite direction
        if (inpHor < 0 && isFacingRight || inpHor > 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            //we flip the player's sprite by changing the local scale of this transform
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        //we update the speed and isgrounded paraments in the animator 
        thisAnimator.SetFloat("Speed", Mathf.Abs(inpHor));
        thisAnimator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        //we update the rigidbody's velocity based on the horizontal input
        rb.velocity = new Vector2(inpHor * speed, rb.velocity.y);
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);//add force to the rigibody that moves it up
        PlayerSoundManager.instance.JumpSoundEffect(); //play jump sound effect from the sound manager
    }
    //we check if the player is grounded using a raycast
    bool isGroundedBool()
    {
        //we cast a raycast down from the players position to check for the ground using a ground layer mask
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundMask);
        return hit.collider != null;
    }
}
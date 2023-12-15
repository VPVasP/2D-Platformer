using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public LayerMask groundMask;
    Animator thisAnimator;
    Rigidbody2D rb;
    float inpHor;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce;
    [SerializeField] bool isGrounded = false;
    [SerializeField] float groundDistance = 0.6f;
    bool isFacingRight;

  
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        inpHor = Input.GetAxis("Horizontal");
        isGrounded = isGroundedBool();

        if (Input.GetKeyDown(KeyCode.Space) && isGroundedBool())
        {
            Jump();
        }

        if (inpHor < 0 && isFacingRight || inpHor > 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        thisAnimator.SetFloat("Speed", Mathf.Abs(inpHor));
        thisAnimator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inpHor * speed, rb.velocity.y);
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        PlayerSoundManager.instance.JumpSoundEffect();
    }
    bool isGroundedBool()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundMask);
        return hit.collider != null;
    }
}
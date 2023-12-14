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
    SpriteRenderer spriteRenderer;
    [SerializeField] bool isGrounded = false;
    [SerializeField] float groundDistance = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inpHor = Input.GetAxis("Horizontal");
        isGrounded = isGroundedBool();
        //transform.position += Vector3.right * inpHor * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) &&isGroundedBool())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        if (inpHor < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (inpHor > 0)
        {
            spriteRenderer.flipX = false;

        
        }
        thisAnimator.SetFloat("Speed", Mathf.Abs(inpHor));
        thisAnimator.SetBool("isGrounded", isGrounded);
    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(inpHor *speed, rb.velocity.y);
    }
    bool isGroundedBool()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,groundDistance,groundMask);
        if (hit.collider != null) { return true; }
        else return false;
    }
}
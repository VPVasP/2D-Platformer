using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Animator thisAnimator;
    Rigidbody2D rb;
    float inpHor;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce;
    SpriteRenderer spriteRenderer;
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

        //transform.position += Vector3.right * inpHor * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
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

            thisAnimator.SetFloat("Speed", Mathf.Abs(inpHor));
        }
    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(inpHor *speed, rb.velocity.y);
    }
}
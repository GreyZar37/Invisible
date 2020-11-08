using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveInput;
    public float speed;

    private bool facingRight = true;

    Rigidbody2D rb;

    public static bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    public int jumpForce;

    public int ekstraJumpValue;
    private int ekstraJumps;

   


    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(ekstraJumps);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);



        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

      

      
    }

    private void Update()
    {

        anim.SetFloat("y.Velocity", rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else if (moveInput != 0)
        {
            anim.SetBool("isWalking", true);
        }


        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else if(isGrounded != true)
        {
            anim.SetBool("isJumping", true);
        }


        if (isGrounded == true)
        {
            ekstraJumps = ekstraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ekstraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            ekstraJumps--;
            anim.SetBool("isJumping", true);
        }

      
        else if (Input.GetKeyDown(KeyCode.Space) && ekstraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

      
        }


      

    }
    public void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0);
    }
}

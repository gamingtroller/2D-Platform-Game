using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpValue;

   




    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        




    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);

        Move();
        CheckFacingDirection();
        Jump();
       
    }



    void Move() //movement and input function
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }


    void Flip() //facing flips action
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }

    void CheckFacingDirection() //check for facing direction
    {
        if (facingRight == false && moveInput > 0)
        {
            Flip();

        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Jump()
    {
        //check on ground and reset extra jump counter
        if (isGrounded && extraJumps != extraJumpValue)
        {
            extraJumps = extraJumpValue;
        }


        //checks for extra jump every jump
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }//jump again if on ground and all extra jump is done
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {

            rb.velocity = Vector2.up * jumpForce;
        }

    }


}//end 

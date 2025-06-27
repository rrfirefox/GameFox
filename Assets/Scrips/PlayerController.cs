using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer theSR;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCkeckpoint;
    public LayerMask whatIsGround;

    public float knockBackLength, knockBackForce;
    public float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()

    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(knockBackCounter <= 0)
        {
            theRB.linearVelocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.linearVelocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCkeckpoint.position, .2f, whatIsGround);

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }

            }

            if (theRB.linearVelocity.x < 0)
            {
                theSR.flipX = true;
            }
            else if (theRB.linearVelocity.x > 0)
            {
                theSR.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if (!theSR.flipX)
            {
                theRB.linearVelocity = new Vector2(-knockBackForce, theRB.linearVelocity.y);
            }
            else
            {
                theRB.linearVelocity = new Vector2(knockBackForce, theRB.linearVelocity.y);
            }
        }
        

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void Knockback()
    {
        knockBackCounter = knockBackLength;
        theRB.linearVelocity = new Vector2(0f , knockBackForce);
    }
}

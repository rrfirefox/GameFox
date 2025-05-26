using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Animator")]
    private Animator anim;
    private SpriteRenderer theSR;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCkeckpoint;
    public LayerMask whatIsGround;


    void Start()

    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        theRB.linearVelocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCkeckpoint.position, .2f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
            }else
            {
                if(canDoubleJump)
                {
                    theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
            
        }

        if(theRB.linearVelocity.x < 0)
        {
            theSR.flipX = true;
        }else if(theRB.linearVelocity.x > 0)
        {
            theSR.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

}

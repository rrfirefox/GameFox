using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim;

    public float moveTime, waitTime;
    private float moveCount, waitCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                theRB.linearVelocity = new Vector2(moveSpeed, theRB.linearVelocity.y);
                theSR.flipX = true;
                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.linearVelocity = new Vector2(-moveSpeed, theRB.linearVelocity.y);
                theSR.flipX = false;
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }

            anim.SetBool("isMoving", true);
        }else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.linearVelocity = new Vector2(0f, theRB.linearVelocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", false);
        }

    }
}
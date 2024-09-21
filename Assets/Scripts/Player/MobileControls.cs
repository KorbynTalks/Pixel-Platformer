using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    private float jumpingPower = 16f;
    public float speed = 5;
    public Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void PointerDownLeft()
    {
        animator.SetFloat("Speed", 1f);
        moveLeft = true;
    }
    public void JumpDown()
    {
        if(!IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Debug.Log("Jump Please");
        }
    }
    public void JumpUp()
    {
        if(rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    public void PointerUpLeft()
    {
        animator.SetFloat("Speed", 0f);
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        animator.SetFloat("Speed", 1f);
        moveRight = true;
    }

    public void PointerUpRight()
    {
        animator.SetFloat("Speed", 0f);
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}

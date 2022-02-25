using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentScript2 : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    public LayerMask groundLayerMask;
    public GameObject groundChecker;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Rigidbody2D r2d;

    Animator anim;

    private void Awake()
    {
        //Sets the animator component
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = transform.localScale.x > 0;
    }

    void Update()
    {
        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
        {
            // Moving
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                // Not Moving
                moveDirection = 0;
            }
        }

        //Animations

        //Left and right walking
        if (r2d.velocity.y > 0 || r2d.velocity.y < 0)
        {
            anim.SetFloat("anim", 6);
        }
        else if(moveDirection == 0)
        {
            anim.SetFloat("anim", 11);
        }

        //Jump
        else if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            anim.SetTrigger("jump");
        }
        else
        {
            anim.SetFloat("anim", 11);
        }
        




        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            //Jump
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, 0.14f, groundLayerMask);

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
    }

}

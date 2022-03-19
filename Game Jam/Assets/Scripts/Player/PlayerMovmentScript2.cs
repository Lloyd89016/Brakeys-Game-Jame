using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovmentScript2 : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    public LayerMask groundLayerMask;
    public GameObject groundChecker;
    public Canvas playerCanvas;
    public TMP_Text textMeshProText;

    bool facingRight = true;
    float moveDirection = 0;
    public bool isGrounded = false;
    Rigidbody2D r2d;
    public bool hasStartedJump = false;
    Animator animator;

    private void Awake()
    {
        //Sets the animator component
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = transform.localScale.x > 0;
        hasStartedJump = false;
        isGrounded = false;
    }
    bool isJumping;
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
        if (moveDirection > 0 && isGrounded || moveDirection < 0 && isGrounded)
        {
            animator.SetFloat("Speed", 1);
        }
        else if(moveDirection == 0 && isGrounded)
        {
            animator.SetFloat("Speed", 0);
        }

        if(isGrounded == true)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFloating", false);
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                textMeshProText.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                textMeshProText.GetComponent<RectTransform>().transform.localScale = new Vector3(-1, 1, 1);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            //Jump
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            //StartCoroutine(setIsJumping());
        }

        if (isJumping == true)
        {
            if(animator.GetBool("isFloating") == false)
            {
                animator.SetBool("isJumping", true);
            }

            if (isGrounded == true)
            {
                animator.SetBool("isJumping", false);
                StartCoroutine(Land());
            }
        }


        if (hasStartedJump == false && isGrounded == false)
        {
            StartCoroutine(setIsJumping());
            hasStartedJump = true;
        }
    }
    
    IEnumerator Land()
    {
        animator.SetBool("isFloating", false);
        animator.SetBool("hasLanded", true);
        isJumping = false;
        yield return new WaitForSeconds(.1f);
        animator.SetBool("hasLanded", false);
        yield return new WaitForSeconds(.1f);
        hasStartedJump = false;
    }

    IEnumerator setIsJumping()
    {
        yield return new WaitForSeconds(.05f);
        isJumping = true;
        yield return new WaitForSeconds(.5f);
        animator.SetBool("isJumping", false);
        animator.SetBool("isFloating", true);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, 0.14f, groundLayerMask);

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "checkpoint")
        {
            playerCanvas.GetComponent<TypeWriterEffect>().RunTMP(collision.GetComponent<checkpoint>().whatToSayOrThink, textMeshProText, collision.GetComponent<checkpoint>().stayingTime);
            Destroy(collision.gameObject);
        }
    }

}

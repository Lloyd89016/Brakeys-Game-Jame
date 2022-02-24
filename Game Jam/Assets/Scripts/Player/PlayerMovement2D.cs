using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Neccessary")]
    public LayerMask groundLayerMask;
    public GameObject groundChecker;

    [Header("Platformer")]
    public bool isPlatformer = false;

    public float isPlatformer_jumpRadius = 5f;

    [Header("Other Settings")]
    public bool useRoughMovements = false;

    public float speed = 5f;

    public float jumpPower = 5f;

    Rigidbody2D rb2D;

    //public bool UsePhysics = false;

    // Private variables that are not shown in inspector.

    private float HorizontalInput;

    float VerticalInput;

    bool canJump;

    Animator anim;

    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 prevPos = transform.position;

        if (useRoughMovements)
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            HorizontalInput  = Input.GetAxis("Horizontal");
        }
        VerticalInput = Input.GetAxisRaw("Vertical"); // raw for this, because jumping speed doesnt have to be accelerated

        Vector2 position = transform.position;
        position.x += speed * HorizontalInput * Time.deltaTime;


        //It now jumps with rb2d so that it feels more like a jump you can swich it out bu un commenting the code below this and deleting the if statment with the add fource
        //position.y += speed * VerticalInput * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W) && canJump == true || Input.GetKeyDown(KeyCode.UpArrow) && canJump == true)
            {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
            }

        //I changed this to a MoveTowards to see if it would work. it seemed to. you can change it back if u want
        transform.position = Vector3.MoveTowards(transform.position, position, speed);

        if (prevPos.x != position.x)
        {
            anim.SetFloat("anim", 6);
        }
        else if (prevPos.x == position.x)
        {
            anim.SetFloat("anim", 11);
        }

        if (rb2D.velocity.y >= 1 && rb2D.velocity.y < jumpPower)
        {
            anim.SetTrigger("jump");
        }
        

        //transform.position = position;
        

        if (isPlatformer)
        {
            canJump = Physics2D.OverlapCircle(groundChecker.transform.position, isPlatformer_jumpRadius, groundLayerMask);
        }
    }

    /*private void FixedUpdate()
    {

            if (GetComponent<Rigidbody2D>() == null)
            {
                Debug.LogError("You have UsePhysics variable checked in the PlayerMovement2D. You need to add a rigidbody2d to the gameobject in order to work with physics.");
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * HorizontalInput, GetComponent<Rigidbody2D>().velocity.y);

            if (canJump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed * VerticalInput);
            }
    }*/ // enabling the velocity idk caused a gravity error, im looking into that rn, but we wont be facing any problems without
        // velocity so this code is useless in this case because Input.GetAxis enables acceleration anyways...
}

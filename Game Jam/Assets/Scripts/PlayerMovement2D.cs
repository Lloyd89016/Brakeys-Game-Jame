using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

    // SCRIPT IN PROGRESS: SCRIPT IS NOT READY YET.
    [Header("Neccessary")]
    public LayerMask groundLayerMask;

    [Header("Platformer")]
    public bool isPlatformer = false;

    public float isPlatformer_jumpRadius = 5f;

    [Header("Other Settings")]
    public bool useRoughMovements = false;

    public float speed = 5f;

    //public bool UsePhysics = false;

    // Private variables that are not shown in inspector.

    private float HorizontalInput;

    float VerticalInput;

    bool canJump;

    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            position.y += speed * VerticalInput * Time.deltaTime;
            transform.position = position;
        

        if (isPlatformer)
        {
            canJump = Physics2D.OverlapCircle(transform.position, isPlatformer_jumpRadius, groundLayerMask);
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

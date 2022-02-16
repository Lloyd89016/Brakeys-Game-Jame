using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    //public bool isPlatformer; // variable not ready yet // we'll make the player check for the ground in order to jump in that ig.

    public bool useRoughMovements;

    public float speed = 5f;

    public bool UsePhysics;

    

    // Private variables that are not shown in inspector.

    private float HorizontalInput;

    float VerticalInput;

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
            VerticalInput = Input.GetAxisRaw("Vertical");
        }
        else
        {
            HorizontalInput  = Input.GetAxis("Horizontal");
            VerticalInput = Input.GetAxis("Vertical");
        }

        if (!UsePhysics)
        {
            Vector2 position = transform.position;
            position.x += speed * HorizontalInput;
            position.y += speed * VerticalInput;
            transform.position = position;
        }
    }

    private void FixedUpdate()
    {
        if (UsePhysics)
        {
            if (GetComponent<Rigidbody2D>() == null)
            {
                Debug.LogError("You have UsePhysics variable checked in the PlayerMovement2D. You need to add a rigidbody2d to the gameobject in order to work with physics.");
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * HorizontalInput, speed * VerticalInput);
        }
    }
}

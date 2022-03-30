using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerMovmentScript : MonoBehaviour
{
    // Move player in 2D space

    //Movement stuff
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    private bool canWalk;
    private Rigidbody2D r2d;
    private bool facingRight = true;
    private float moveDirection = 0;
    private bool isGrounded = false;
    private bool hasStartedJump = false;
    Animator animator;
    RigidbodyConstraints2D originalConstraints;
    public LayerMask groundLayerMask;
    public GameObject groundChecker;
    private bool isJumping;

    //Text
    public float dialogueClearTime = 3f;
    public Canvas playerCanvas;
    public TMP_Text textMeshProText;

    //Lighting stuff
    public Light2D globalLight;
    public float globalLightatStartValue = 0.05f;

    //Sound Stuff
    public AudioSource WalkingAudioSource;
    public AudioSource JumpingAudioSource;
    public AudioSource LandingAudioSource;

    public AudioClip[] walkingSounds;
    public AudioClip[] JumpingSounds;
    public AudioClip[] LandingSounds;

    private void Awake()
    {
        //Sets the animator component
        animator = GetComponent<Animator>();
        globalLight.intensity = globalLightatStartValue; // makes life of developers easier...
    }


    void Start()
    {

        setVariables();
        //Starts the corountine that playes random animations
        StartCoroutine(randomAnimations());
        StartCoroutine(playerWalkingSounds());
    }

    void setVariables()
    {
        //lets the player walk
        canWalk = true;

        //Sets the rigidbody
        r2d = GetComponent<Rigidbody2D>();

        //Gets the orignal constaints so it can go back to them at any time
        originalConstraints = r2d.constraints;

        //Stops the player from being able to rotate
        r2d.freezeRotation = true;

        //Sets the ridged body detection mode to continuous.
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        //Sets the ridgedbodys gravity scale to the gravity scale variable
        r2d.gravityScale = gravityScale;

        //Sets the facing right varable to right.
        facingRight = transform.localScale.x > 0;

        //Sets some variable I can't be bothered to explain here.
        hasStartedJump = false;

        //Is the player on the ground?
        isGrounded = false;

        //Sound
        
    }

    void Update()
    {
        movement();
    }

    void movement()
    {

        // Movement controls
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && isGrounded == true || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            animator.SetFloat("Speed", 2);
            moveDirection = Input.GetKey(KeyCode.A) ? -1.5f : 1.5f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            // Moving
            animator.SetFloat("Speed", 1);
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                // Not Moving
                moveDirection = 0;
                animator.SetFloat("Speed", 0);
            }
        }

        //Stops any random animation playing on the press of a key
        if (Input.anyKeyDown)
        {
            animator.SetInteger("RandomAnimation", 0);
        }

        //Makes sure that if the player is on the ground no air animtions can play
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFloating", false);
        }

        if (canWalk == true)
        {
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
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            //Jump
            if (canWalk == true)
            {
                JumpingAudioSource.clip = JumpingSounds[Random.Range(0, JumpingSounds.Length)];
                JumpingAudioSource.Play();
                r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            }
        }

        if (isJumping == true)
        {
            //If the player is jumping and isent playing the floating animation then it will play the jumping animation
            if (animator.GetBool("isFloating") == false)
            {
                animator.SetBool("isJumping", true);
            }

            //This starts the landing sequence.
            if (isGrounded == true)
            {
                //Freezes the player so that he cant move
                r2d.constraints = RigidbodyConstraints2D.FreezeAll;

                //Stops the jumping animation
                animator.SetBool("isJumping", false);

                //starts the landing sequence.
                StartCoroutine(Land());
            }
        }

        //Checks to see if the player is jumping. It has the hasStartedJump so that if the player is already in the air it dosent keep calling.
        if (hasStartedJump == false && isGrounded == false)
        {
            //Starts the "hasStartedJump" Coroutine so that the correct animations can play
            StartCoroutine(setIsJumping());

            //Sets the "hasStartedJump" variable to true so that this if statment cant call again untill the player has landed
            hasStartedJump = true;
        }

        //Checks if the player is touching the ground by puting a circle at its feet and seeing if anything is touching that. Then it looks for the layer the circle it touching. If it has the ground layer the yeipee its touching the ground. Lovley.
        isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, 0.2f, groundLayerMask);
    }

    IEnumerator Land()
    {
        //Stops the floating animation
        animator.SetBool("isFloating", false);

        //starts the land animation
        animator.SetBool("hasLanded", true);

        LandingAudioSource.clip = LandingSounds[Random.Range(0, LandingSounds.Length)];
        LandingAudioSource.Play();

        //Makes the player not abke to walk
        canWalk = false;

        //Stops the if statment whitch starts the jumping animation and on land starts the land if statment for landing whitch calls the land Coroutine(this coroutine) becuse this is called when the player has landed so the player is no longer jumping.
        isJumping = false;

        //Waits for a bit so that
        yield return new WaitForSeconds(.1f);

        //Stops the land animation
        animator.SetBool("hasLanded", false);

        //waits a bit before leting the player move again
        yield return new WaitForSeconds(.2f);

        //unlocks the players x position so he can move again
        r2d.constraints = originalConstraints;

        //lets the player walk again
        canWalk = true;

        //Waits a bit. Idk why but im not gonna question it.
        yield return new WaitForSeconds(.1f);

        //Resets the thing to detect if the player is jumping.
        hasStartedJump = false;
    }

    IEnumerator setIsJumping()
    {
        //Waits. For some reason. Ill just let that be.
        yield return new WaitForSeconds(.05f);

        //Starts the jumping if statment whitch starts the jumping animation and on land starts the land if statment for landing whitch calls the land Coroutine. Jesus f**k im bad at writing clean code.
        isJumping = true;

        //Waits untill the jumping animation ends so it can switch to floating
        yield return new WaitForSeconds(.5f);

        //stops the jumping animation 
        animator.SetBool("isJumping", false);

        //Starts the floating animation becuse the jump animation ended and after you jump you fall until you land. Physics are pretty sick.
        animator.SetBool("isFloating", true);
    }

    //Play random animations whilst standing still
    IEnumerator randomAnimations()
    {
        float waitTime = Random.Range(1, 30);
        yield return new WaitForSeconds(waitTime);
        if (Input.anyKey == false && isGrounded == true)
        {
            animator.SetInteger("RandomAnimation", 1);
        }
        yield return new WaitForSeconds(1);
        animator.SetInteger("RandomAnimation", 0);

        waitTime = Random.Range(1, 30);
        yield return new WaitForSeconds(waitTime);
        if (Input.anyKey == false && isGrounded == true)
        {
            animator.SetInteger("RandomAnimation", 2);
        }
        yield return new WaitForSeconds(1);
        animator.SetInteger("RandomAnimation", 0);
        StartCoroutine(randomAnimations());
    }

    IEnumerator playerWalkingSounds()
    {
        float WaitTime = .2f;
        yield return new WaitForSeconds(.0001f);
        if (moveDirection == 1.5f && isGrounded == true || moveDirection == -1.5f && isGrounded == true)
        {
            WaitTime = .15f;
            WalkingAudioSource.clip = walkingSounds[Random.Range(0, walkingSounds.Length)];
            WalkingAudioSource.Play();
        }
        else if(moveDirection != 0 && isGrounded == true)
        {
            WaitTime = .3f;
            WalkingAudioSource.clip = walkingSounds[Random.Range(0, walkingSounds.Length)];
            WalkingAudioSource.Play();
        }
        else
        {
            WalkingAudioSource.Stop();
            WaitTime = .001f;
        }

        yield return new WaitForSeconds(WaitTime);
        StartCoroutine(playerWalkingSounds());
    }

    void FixedUpdate()
    {
        //Moves if the "canWalk" is true. The only reason it wouldent be is if the player just landed.
        if(canWalk == true)
        {
            //Apply movement velocity 
            r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
        }
    }

    //When the player hits a trigger it playes a typewriter effect and displays the text
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "checkpoint")
        {
            playerCanvas.GetComponent<TypeWriterEffect>().RunTMP(collision.GetComponent<checkpoint>().whatToSayOrThink, textMeshProText, collision.GetComponent<checkpoint>().stayingTime);
            StartCoroutine(clearDialogue(dialogueClearTime));
            Destroy(collision.gameObject);
        }
    }
    // clearing the dialogue
    IEnumerator clearDialogue(float dialogueClearTime)
    {
        yield return new WaitForSeconds(dialogueClearTime);
        textMeshProText.text = string.Empty;
    }

}

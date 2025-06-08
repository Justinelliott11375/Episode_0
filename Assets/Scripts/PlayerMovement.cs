using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	private Rigidbody2D rb;
	private Vector2 movement;

	private Animator animator;
	private Vector2 Iswalking;

    private SpriteRenderer spriteRenderer;//Flip right animation


    // Start is called before the first frame update
    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Initialize the SpriteRenderer
    }

	// Update is called once per frame
	void Update()
	{
		ProcessInputs();
		Animate();


    }

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
	}

    void ProcessInputs()
    {

		float InputX = Input.GetAxisRaw("Horizontal");
		float InputY = Input.GetAxisRaw("Vertical");

        //needs if statement asking is getting input set inputx/y bool to false


        // Get input from the player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


		if ((InputX == 0 && InputY == 0) && (movement.x != 0 || movement.y != 0))
		{
			Iswalking = movement;

		}

        // Get input from the player

        /*movement.x = InputX;
        movement.y = InputY;*/

        // Flip sprite if moving right only
        if (InputX == 1 && InputY == 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        /*if ((InputX == 0 && InputY == 0) && (movement.x != 0 || movement.y != 0))
        {
            Iswalking = movement;
        }
        if ((InputX == 1 && InputY == 0))
        {
            Iswalking = movement;
        }*/





    }
	void Animate()
	{

        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
		animator.SetFloat("Iswalking 0", movement.magnitude);

    }






}

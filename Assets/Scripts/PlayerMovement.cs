using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	private Rigidbody2D rb;
	private Vector2 movement;
	private Vector2 lastMovementDirection;


	private Animator animator;

    private SpriteRenderer spriteRenderer;
	private PlayerInputProcessor inputProcessor = new PlayerInputProcessor();


    // Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		movement = inputProcessor.GetMovementVector(inputX, inputY);

		if (movement != Vector2.zero)
		{
			lastMovementDirection = movement.normalized;
		}

		spriteRenderer.flipX = inputProcessor.ShouldFlipSprite(inputX, inputY);
    }
	void Animate()
	{
        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);

		float speed = inputProcessor.GetSpeed(movement);
		animator.SetFloat("Speed", speed);
    }
}

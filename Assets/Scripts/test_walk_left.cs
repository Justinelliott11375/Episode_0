using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_walk_left : MonoBehaviour
{
	public Animator animator;

	// Update is called once per frame
	void Update()
	{
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (input.x < 0) animator.SetInteger("Direction", 3);
		else animator.SetInteger("Direction", 0);
    }
}

using UnityEngine;

namespace Player
{
	public class PlayerInputProcessor
	{
		public Vector2 GetMovementVector(float inputX, float inputY)
		{
			return new Vector2(inputX, inputY);
		}

		public bool ShouldFlipSprite(float inputX, float inputY)
		{
			return inputX == 1 && inputY == 0;
		}

		public float GetSpeed(Vector2 movement, float deadzone = 0.05f)
		{
			float magnitude = movement.magnitude;
			return magnitude < deadzone ? 0f : magnitude;
		}
	}
}

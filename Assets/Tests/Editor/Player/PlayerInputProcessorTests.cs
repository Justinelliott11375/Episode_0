using NUnit.Framework;
using UnityEngine;
using Player;

public class PlayerInputProcessorTests
{
	private PlayerInputProcessor inputProcessor;

	[SetUp]
	public void SetUp()
	{
		inputProcessor = new PlayerInputProcessor();
	}

	[Test]
	public void GetMovementVector_ReturnsCorrectVector()
	{
		Vector2 result = inputProcessor.GetMovementVector(1, 0);
		Assert.AreEqual(new Vector2(1, 0), result);

		result = inputProcessor.GetMovementVector(0, 1);
		Assert.AreEqual(new Vector2(0, 1), result);

		result = inputProcessor.GetMovementVector(-1, -1);
		Assert.AreEqual(new Vector2(-1, -1), result);
	}

	[Test]
	public void ShouldFlipSprite_ReturnsTrue_WhenFacingRight()
	{
		bool shouldFlip = inputProcessor.ShouldFlipSprite(1, 0);
		Assert.IsTrue(shouldFlip);
	}

	[Test]
	public void ShouldFlipSprite_ReturnsFalse_WhenNotFacingRight()
	{
		bool shouldFlip = inputProcessor.ShouldFlipSprite(-1, 0);
		Assert.IsFalse(shouldFlip);

		shouldFlip = inputProcessor.ShouldFlipSprite(0, 1);
		Assert.IsFalse(shouldFlip);

		shouldFlip = inputProcessor.ShouldFlipSprite(0, 0);
		Assert.IsFalse(shouldFlip);
	}
	[Test]
	public void GetSpeed_WhenMovementIsZero_ReturnsZero()
	{
		var result = inputProcessor.GetSpeed(Vector2.zero);
		Assert.AreEqual(0f, result);
	}

	[Test]
	public void GetSpeed_WhenMovementBelowDeadzone_ReturnsZero()
	{
		var smallMovement = new Vector2(0.01f, 0.01f);
		var result = inputProcessor.GetSpeed(smallMovement);
		Assert.AreEqual(0f, result);
	}

	[Test]
	public void GetSpeed_WhenMovementAboveDeadzone_ReturnsMagnitude()
	{
		var movement = new Vector2(0.1f, 0.1f);
		var result = inputProcessor.GetSpeed(movement);
		Assert.AreEqual(movement.magnitude, result);
	}

	[Test]
	public void GetSpeed_UsesCustomDeadzoneThreshold()
	{
		var movement = new Vector2(0.05f, 0f);
		var result = inputProcessor.GetSpeed(movement, 0.1f);
		Assert.AreEqual(0f, result);
	}
}

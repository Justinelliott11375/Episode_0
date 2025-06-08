using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target; // Assign your player transform in the inspector
	[SerializeField] private float smoothSpeed = 0.125f;
	[SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

	private void LateUpdate()
	{
		if (target == null)
			return;

		transform.position = GetSmoothedCameraPosition(transform.position, target.position, offset, smoothSpeed);
	}

	public static Vector3 GetSmoothedCameraPosition(Vector3 currentPosition, Vector3 targetPosition, Vector3 offset, float smoothSpeed)
	{
		Vector3 desiredPosition = targetPosition + offset;

		return Vector3.Lerp(currentPosition, desiredPosition, smoothSpeed);
	}
}

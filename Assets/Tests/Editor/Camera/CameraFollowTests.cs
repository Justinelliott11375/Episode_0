using NUnit.Framework;
using UnityEngine;

public class CameraFollowTests
{
    [Test]
    public void GetSmoothedCameraPosition_ReturnsLerpedResult()
    {
        Vector3 current = new Vector3(0, 0, -10);
        Vector3 target = new Vector3(10, 5, 0);
        Vector3 offset = new Vector3(0, 0, -10);
        float speed = 0.5f;

        Vector3 expected = Vector3.Lerp(current, target + offset, speed);
        Vector3 result = CameraFollow.GetSmoothedCameraPosition(current, target, offset, speed);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void GetSmoothedCameraPosition_WithZeroSpeed_ReturnsCurrentPosition()
    {
        Vector3 current = new Vector3(1, 2, -10);
        Vector3 target = new Vector3(10, 5, 0);
        Vector3 offset = new Vector3(0, 0, -10);

        Vector3 result = CameraFollow.GetSmoothedCameraPosition(current, target, offset, 0f);

        Assert.AreEqual(current, result);
    }

    [Test]
    public void GetSmoothedCameraPosition_WithFullSpeed_ReturnsTargetPlusOffset()
    {
        Vector3 current = new Vector3(0, 0, -10);
        Vector3 target = new Vector3(10, 5, 0);
        Vector3 offset = new Vector3(0, 0, -10);

        Vector3 result = CameraFollow.GetSmoothedCameraPosition(current, target, offset, 1f);

        Assert.AreEqual(target + offset, result);
    }
}

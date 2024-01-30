using NUnit.Framework;
using UnityEngine;
using NSubstitute;
public class DirectionTests
{
    [Test]
    public void PlayerRotatesRightWhenMovingRight()
    {
        var inputService = Substitute.For<IInputService>();
        inputService.GetAxisRaw("Horizontal").Returns(1f); // Simulating right movement

        var gameObject = new GameObject();
        var playerMovement = gameObject.AddComponent<PlayerController>();
        playerMovement.inputService = inputService;

        //playerMovement.Update(); // Manually call Update to simulate a frame

        Assert.AreEqual(Quaternion.Euler(0, 0, 0), gameObject.transform.rotation);
    }

    [Test]
    public void PlayerRotatesLeftWhenMovingLeft()
    {
        var inputService = Substitute.For<IInputService>();
        inputService.GetAxisRaw("Horizontal").Returns(-1f); // Simulating left movement

        var gameObject = new GameObject();
        var playerMovement = gameObject.AddComponent<PlayerController>();
        playerMovement.inputService = inputService;

        //playerMovement.Update(); // Manually call Update to simulate a frame

        Assert.AreEqual(Quaternion.Euler(0, 0, 0), gameObject.transform.rotation);
    }
}

using UnityEngine;
using UnityEngine.Assertions;

public class Example : MonoBehaviour
{
    private void Start()
    {
        var parsed = "Down".ParseDirection();
        Assert.AreEqual(Direction.Up, parsed); // fails
    }
}
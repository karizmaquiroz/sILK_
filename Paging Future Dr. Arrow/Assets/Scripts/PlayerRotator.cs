using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second
    private int rotationDirection = 0; // -1 = left, 1 = right, 0 = idle

    void Update()
    {
        if (rotationDirection != 0)
        {
            transform.Rotate(0f, rotationDirection * rotationSpeed * Time.deltaTime, 0f);
        }
    }

    // Call from Left Button OnPointerDown
    public void StartRotateLeft()
    {
        rotationDirection = -1;
    }

    // Call from Right Button OnPointerDown
    public void StartRotateRight()
    {
        rotationDirection = 1;
    }

    // Call from both Buttons OnPointerUp
    public void StopRotation()
    {
        rotationDirection = 0;
    }
}

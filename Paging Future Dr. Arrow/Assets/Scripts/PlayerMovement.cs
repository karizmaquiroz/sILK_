using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public Transform pivotPoint; // Assign in the Inspector (e.g., player's position)

    // Called when the Rotate Left button is clicked.
    public void RotateLeft()
    {
        RotateCamera(Vector3.left, -rotationSpeed); // Rotate around the Y-axis (left)
    }

    // Called when the Rotate Right button is clicked.
    public void RotateRight()
    {
        RotateCamera(Vector3.right, rotationSpeed); // Rotate around the Y-axis (right)
    }

    private void RotateCamera(Vector3 axis, float angle)
    {
        transform.RotateAround(pivotPoint.position, axis, angle * Time.deltaTime);
    }
}
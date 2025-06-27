using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public bool verticalLook = true;

    private float xRotation = 0f;

    void Start()
    {
        // Keep cursor visible and free to move
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Read raw mouse delta movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Horizontal rotation (Y-axis)
        transform.Rotate(Vector3.up * mouseX, Space.World);

        if (verticalLook)
        {
            // Clamp vertical rotation (X-axis)
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            Vector3 currentEuler = transform.eulerAngles;
            currentEuler.x = xRotation;
            transform.eulerAngles = new Vector3(xRotation, transform.eulerAngles.y, 0f);
        }
    }
}
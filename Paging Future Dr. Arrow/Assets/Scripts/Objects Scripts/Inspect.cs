using UnityEngine;

public class Inspect : MonoBehaviour
{
    public Transform ObjectToInspect;

    public float rotationSpeed = 100f;

    private Vector3 prevMousePos;

    void Update()
    {

        if (Input.GetMouseButtonDown(0)){ prevMousePos = Input.mousePosition; }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMousePosition = Input.mousePosition - prevMousePos;
            float rotationX = deltaMousePosition.y * rotationSpeed * Time.deltaTime;
            float rotationY = -deltaMousePosition.x * rotationSpeed *Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            ObjectToInspect.rotation = rotation * ObjectToInspect.rotation;

            prevMousePos = Input.mousePosition;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBounce : MonoBehaviour
{
    // Drag and drop Rigidbody in Inspector
    public Rigidbody rb;
    public Vector3 velocity;
    public bool StemCellAquired = false;
    private GameObject StemCell;

    void Start()
    {
        StemCell = this.gameObject;

        // Add force once at start
        rb.AddForce(Vector3.forward * 3.0f, ForceMode.VelocityChange);
    }

    void Update()
    {
        // Track velocity, it holds magnitude and direction (for collision math)
        velocity = rb.linearVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Magnitude of the velocity vector is speed of the object (we will use it for constant speed so object never stop)
        float speed = velocity.magnitude;

        // Reflect params must be normalized so we get new direction
        Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);

        // Like earlier wrote: velocity vector is magnitude (speed) and direction (a new one)
        rb.linearVelocity = direction * speed;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && this.CompareTag("StemCell")){
            this.gameObject.SetActive(false);
            StemCellAquired = true;
        }

        if (Input.GetMouseButtonDown(0) && StemCellAquired == true) {
            this.gameObject.SetActive(true);
            StemCellAquired = false;
            StemCell.transform.position = new Vector3(5, -3.35f, -6.82f);
        }
    }
}
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit)) {
                Debug.Log("Something Hit");
                if (raycastHit.collider.CompareTag("StemCell")) {
                    Debug.Log("Stem Cell!");
                }
            }
        }
    }
}

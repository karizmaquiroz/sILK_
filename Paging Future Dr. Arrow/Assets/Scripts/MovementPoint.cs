using UnityEngine;

public class MovementPoint : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;
    Interactables interactables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f)) {
                if (raycastHit.transform != null) { 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.CompareTag("MovementPoint")) {
            Debug.Log("Moved To: " + gameObject.name.ToString());
            playerTransform.position = gameObject.transform.position + new Vector3(0f, 1.8f, 0f);}
        }

}

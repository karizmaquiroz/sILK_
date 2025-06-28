using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInteractionScript : MonoBehaviour
{

    //Interaction
    [SerializeField] InputAction Mouse;
    Vector2 mousePositionInput;
    Camera myCamera;
    [SerializeField] InputAction Interaction;
    [SerializeField] LayerMask interactionLayer;


    private void Awake()
    {
        Interaction.performed += Interact;
    }


    private void OnEnable()
    {
        Mouse.Enable();
        Interaction.Enable();
    }

    private void OnDisable()
    {
        Mouse.Disable();
        Interaction.Disable();
    }


    public void Update()
    {
        mousePositionInput = Mouse.ReadValue<Vector2>();
    }


    void Interact(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(mousePositionInput); ;
            if(Physics.Raycast(ray, out hit, interactionLayer))
            {
                if (hit.transform.tag == "Interactable")
                {
                    if (hit.transform.GetChild(0).gameObject.activeInHierarchy)
                        return;

                    Interactables temp = hit.transform.GetComponent<Interactables>();
                    temp.PlayMiniGame(); //would call scene minigame in Interactable game
                }
            }
        }
    }

}

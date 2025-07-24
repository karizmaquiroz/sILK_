using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//contains the raycast for the notebook
public class Inspect : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float rayLength = 5;
    private Interactables viewableNote;
    private Camera _camera;

    [Header("Input Key")]
    [SerializeField] private KeyCode interactKey;


    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
        {
            var noteItem = hit.collider.GetComponent<Interactables>();
            if (noteItem != null)
            {
                viewableNote = noteItem;
                HighlightCrosshair(true);
            }
            else
            {
                ClearExaminable();
            }
        }
        else
        {
            ClearExaminable();
        }

        if (viewableNote != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                viewableNote.ShowNote();
            }
        }
    }

    private void ClearExaminable()
    {
        if (viewableNote != null)
        {
            HighlightCrosshair(false);
            viewableNote = null;
        }
    }

    void HighlightCrosshair(bool on)
    {
        DebriefUIManager.instance.HighlightCrosshair(on);
    }

}


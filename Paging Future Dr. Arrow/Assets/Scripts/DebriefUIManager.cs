using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DebriefUIManager : MonoBehaviour
{

    [Header("Should persist?")]
    [SerializeField] private bool persistAcrossScenes = true;

   

    [Header("Page Buttons UI")]
    [SerializeField] private GameObject pageButtons = null;
    [SerializeField] private GameObject nextButton = null;
    [SerializeField] private GameObject previousButton = null;

    [Header("Main Note Settings")]
    [SerializeField] private CanvasGroup NoteContainer = null;
    [SerializeField] private Image notePageUI = null;
    [SerializeField] private TMP_Text noteTextUI = null;

    [Header("Overlay Settings")]
    [SerializeField] private CanvasGroup overlayPanelBG = null;
    [SerializeField] private Image overlayTextBG = null;
    [SerializeField] private TMP_Text overlayTextUI = null;
    [SerializeField] private GameObject overlayButtons = null;


    [Header("Crosshair")]
    [SerializeField] private Image crosshair = null;

   

    [Header("Interact Prompt Notification")]
    [SerializeField] private CanvasGroup interactPromptCanvas = null;

    public ClipboardController NoteController { get; set; }

    public bool IsInventoryOpen => isOpen; // Add this property to expose the inventory state

    private bool isOpen = false;
    //private bool shouldToggle = false;
    private HashSet<string> addedNoteIDs = new HashSet<string>();

    public static DebriefUIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            if (persistAcrossScenes)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    private void Start()
    {
        
        FieldNullCheck();
    }



    public void BasicNoteInitialize(Sprite pageImage, Vector2 noteScale)
    {
        DisplayPage(pageImage);
        notePageUI.rectTransform.sizeDelta = noteScale;
        DisableNoteDisplay(true);
    }

    public void InitialiseMainNote(Sprite pageImage, Vector2 pageScale, string pageText, Vector2 mainTextAreaScale, int mainTextSize, TMP_FontAsset mainFontAsset, Color mainFontColor)
    {
        DisplayPage(pageImage);
        DisableNoteDisplay(true);

        notePageUI.rectTransform.sizeDelta = pageScale;
        noteTextUI.text = pageText;

        noteTextUI.rectTransform.sizeDelta = mainTextAreaScale;
        noteTextUI.fontSize = mainTextSize;

        noteTextUI.font = mainFontAsset;

        noteTextUI.color = mainFontColor;
    }

    public void InitialiseOverlay(Color overlayBGColor, Vector2 overlayTextAreaScale, string noteText, int overlayTextSize, TMP_FontAsset overlayFontAsset, Color overlayFontColor, Vector2 overlayTextBGScale)
    {
        overlayTextBG.color = overlayBGColor;

        overlayTextUI.rectTransform.sizeDelta = overlayTextAreaScale;
        overlayTextUI.text = noteText;

        overlayTextUI.fontSize = overlayTextSize;
        overlayTextUI.font = overlayFontAsset;
        overlayTextUI.color = overlayFontColor;

        overlayTextBG.rectTransform.sizeDelta = overlayTextBGScale;
    }

    public void HideMainNoteDisplay(bool enabled)
    {
        noteTextUI.enabled = enabled;
    }

    public void DisplayPage(Sprite pageImage)
    {
        notePageUI.sprite = pageImage;
    }

    public void FillNoteText(string noteText)
    {
        noteTextUI.text = noteText;
        overlayTextUI.text = noteText;
    }

    public void DisableNoteDisplay(bool active)
    {
        NoteContainer.alpha = active ? 1 : 0;
        NoteContainer.interactable = active;
        NoteContainer.blocksRaycasts = active;
    }

    public void ShowOverlay(bool active)
    {
        overlayPanelBG.alpha = active ? 1 : 0;
        overlayPanelBG.interactable = active;
        overlayPanelBG.blocksRaycasts = active;
    }

    public void ShowOverlayButton(bool show)
    {
        overlayButtons.SetActive(show);
    }

    public void ShowPageButtons(bool shouldShow)
    {
        if (shouldShow)
        {
            pageButtons.SetActive(true);
        }
        else
        {
            pageButtons.SetActive(false);
        }
    }

    public void ShowPreviousButton(bool show)
    {
        previousButton.SetActive(show);
    }

    public void ShowNextButton(bool show)
    {
        nextButton.SetActive(show);
    }

   
    public void ShowOverlayButton()
    {
        NoteController.ToggleOverlay();
    }

    public void CloseButton()
    {
        NoteController.CloseNote();
    }

    public void NextPageButton()
    {
        NoteController.NextPage();
    }

    public void BackPageButton()
    {
        NoteController.BackPage();
    }

    public void ShowInteractPrompt(bool on)
    {
        interactPromptCanvas.alpha = on ? 1 : 0;
    }

    public void HighlightCrosshair(bool on)
    {
        crosshair.color = on ? Color.red : Color.white;
    }

    public void HideCursor(bool hide)
    {
        Cursor.lockState = hide ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !hide;
        crosshair.enabled = hide;
    }

    void DebugReferenceCheck()
    {
        if (crosshair == null)
        {
            print("GenericUIManager: Add the crosshair UI element to the inspector");
        }

       
        if (interactPromptCanvas == null)
        {
            print("GenericUIManager: If you're using a trigger event type, make sure to add the interact prompt UI element to the inspector otherwise ignore this");
        }
    }

    void FieldNullCheck()
    {
        // Checking each field and logging an error if it is null
        

        CheckField(pageButtons, "PageButtons");
        CheckField(nextButton, "NextButton");
        CheckField(previousButton, "PreviousButton");

        CheckField(NoteContainer, "NoteContainer");
        CheckField(notePageUI, "NotePageUI");
        CheckField(noteTextUI, "NoteTextUI");

        CheckField(overlayPanelBG, "OverlayPanelBG");
        CheckField(overlayTextBG, "OverlayTextBG");
        CheckField(overlayTextUI, "OverlayTextUI");
        CheckField(overlayButtons, "OverlayButtons");

   

        CheckField(crosshair, "Crosshair");

      

        CheckField(interactPromptCanvas, "InteractPromptCanvas");
    }

    void CheckField(Object field, string fieldName)
    {
        if (field == null)
        {
            Debug.LogError($"FieldNullCheck: {fieldName} is not set in the inspector!");
        }
    }
}


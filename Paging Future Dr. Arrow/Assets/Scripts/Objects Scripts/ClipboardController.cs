using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;



public class ClipboardController : MonoBehaviour
{

    [Space(10)]
    [SerializeField] private PlayerMovement Player;

    [Space(10)]

    private ClipboardData noteData = null;
    private int pageNum = 0;
    private bool showOverlay;
    private bool audioPlaying;
    private bool canCloseNote;
    private bool isNoteBeingViewed;
    private DebriefUIManager noteUIController;
    private GameObject triggerObject;

    public enum NoteSource { None, Inventory, World }

    public NoteSource CurrentNoteSource { get; set; }

    public bool IsNoteBeingViewed
    {
        get { return isNoteBeingViewed; }
        set { isNoteBeingViewed = value; }
    }

    [Header("Should persist?")]
    [SerializeField] private bool persistAcrossScenes = true;

    public static ClipboardController instance;

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

    private void Update()
    {
        if (isNoteBeingViewed && canCloseNote && Input.GetKeyDown(ClipboardInputManager.instance.closeKey))
        {
            CloseNote();
        }
    }

    void DisablePlayer(bool disable)
    {
        Player.enabled = !disable;
    }


    public void ShowNote(ClipboardData newNoteData)
    {
        DebriefUIManager.instance.NoteController = gameObject.GetComponent<ClipboardController>();
        noteUIController = DebriefUIManager.instance;

        noteData = newNoteData;

       

        isNoteBeingViewed = true;
        canCloseNote = false;

        StartCoroutine(WaitTime());
        DisablePlayer(true); // NoteDisableManager.instance.DisablePlayer(true);

       

        if (pageNum <= 1)
        {
            noteUIController.ShowPreviousButton(false);
        }

        if (noteData.ShowNavigationButtons)
        {
            noteUIController.ShowPageButtons(true);
        }

        noteUIController.InitialiseMainNote(noteData.PageImages[pageNum], noteData.PageScale, noteData.PageText[pageNum], noteData.MainTextAreaScale, noteData.MainTextSize,
                    noteData.MainFontAsset, noteData.MainFontColor);

        if (!noteData.ShowTextOnMainPage)
        {
            noteUIController.HideMainNoteDisplay(false);
        }

        if (noteData.EnableOverlayText)
        {
            noteUIController.InitialiseOverlay(noteData.OverlayBGColor, noteData.OverlayTextAreaScale, noteData.PageText[pageNum], noteData.OverlayTextSize,
                noteData.OverlayFontAsset, /*noteData.OverlayFontStyle,*/ noteData.OverlayFontColor, noteData.OverlayTextBGScale);

            noteUIController.ShowOverlayButton(true);

            if (noteData.ShowOverlayOnOpen)
            {
                ToggleOverlay();
            }
        }

      

        if (noteData.IsNoteTrigger)
        {
            EnableTrigger(false);
        }
    }

    public void CloseNote()
    {
        noteUIController.DisableNoteDisplay(false);
        noteUIController.ShowOverlay(false);

        DisablePlayer(false);


        isNoteBeingViewed = false;
        showOverlay = false;
        canCloseNote = false;
        ResetNote();

      

        // Reset the note source after handling it
        CurrentNoteSource = NoteSource.None;

        if (!noteData.ShowTextOnMainPage)
        {
            noteUIController.HideMainNoteDisplay(true);
        }

        if (noteData.ShowNavigationButtons)
        {
            noteUIController.ShowPageButtons(false);
        }

        if (noteData.EnableOverlayText)
        {
            noteUIController.ShowOverlayButton(false);
        }

       


        if (noteData.IsNoteTrigger)
        {
            EnableTrigger(true);
        }
    }

    public void ToggleOverlay()
    {

        showOverlay = !showOverlay;
        noteUIController.ShowOverlay(showOverlay);
    }

    public void NextPage()
    {
        // If pageNum hasn't reached the maximum index of the longer array, then increment pageNum
        if (pageNum < Mathf.Max(noteData.PageImages.Length, noteData.PageText.Length) - 1)
        {
            pageNum++;
        }

        if (pageNum < noteData.PageText.Length) // Check bounds for pageText
        {
            noteUIController.FillNoteText(noteData.PageText[pageNum]);
        }
        if (pageNum < noteData.PageImages.Length) // Check bounds for basicPageImages again
        {
            noteUIController.DisplayPage(noteData.PageImages[pageNum]);
        }

        EnabledButtons();

        // If pageNum has reached the maximum index of the longer array, hide the next button
        if (pageNum >= Mathf.Max(noteData.PageImages.Length, noteData.PageText.Length) - 1)
        {
            noteUIController.ShowNextButton(false);
        }
    }

    public void BackPage()
    {
        // Check if pageNum is greater than 0, allowing us to go back
        if (pageNum > 0)
        {
            pageNum--;

            // Only fill note text if pageNum is within bounds for pageText array
            if (pageNum < noteData.PageText.Length)
            {
                noteUIController.FillNoteText(noteData.PageText[pageNum]);
            }

            // Only display page if pageNum is within bounds for basicPageImages array
            if (pageNum < noteData.PageImages.Length)
            {
                noteUIController.DisplayPage(noteData.PageImages[pageNum]);
            }

            EnabledButtons();


            // If pageNum is at the start, hide the previous button
            if (pageNum == 0)
            {
                noteUIController.ShowPreviousButton(false);
            }
        }
    }

    void ResetNote()
    {
        noteUIController.ShowPreviousButton(false);
        noteUIController.ShowNextButton(true);
        pageNum = 0;
    }

    void EnabledButtons()
    {
        noteUIController.ShowPreviousButton(true);
        noteUIController.ShowNextButton(true);
    }

    public void GetTriggerObject(GameObject foundTriggerObject)
    {
        triggerObject = foundTriggerObject;
    }

    private void EnableTrigger(bool enable)
    {
        if (triggerObject != null)
        {
            triggerObject.SetActive(enable);
        }
    }

    IEnumerator WaitTime()
    {
        const float WaitTimer = 0.1f;
        yield return new WaitForSeconds(WaitTimer);
        canCloseNote = true;
    }

    void PlayFlipAudio()
    {
        if (noteData.NotePageAudio != null)
        {
            NoteAudioManager.instance.Play(noteData.NotePageAudio);
        }
        else
        {
            Debug.Log("Note Scriptable on" + " " + noteData.name + ": Add a reference to the note flip sound Scriptable to the inspector");
        }
    }

    public void NoteReadingAudio()
    {
        if (!audioPlaying)
        {
            PlayAudio();
        }
        else
        {
            PauseAudio();
        }
    }

    public void RepeatReadingAudio()
    {
        StopAudio();
        PlayAudio();
    }

    public void PlayAudio()
    {
        if (noteData.NoteReadAudio != null)
        {
            NoteAudioManager.instance.Play(noteData.NoteReadAudio);
            audioPlaying = true;
        }
        else
        {
            Debug.Log("Note Scriptable on" + " " + noteData.name + ": Add a reference to the reading sound Scriptable to the inspector");
        }
    }

    public void StopAudio()
    {
        NoteAudioManager.instance.StopPlaying(noteData.NoteReadAudio);
        audioPlaying = false;
    }

    public void PauseAudio()
    {
        NoteAudioManager.instance.PausePlaying(noteData.NoteReadAudio);
        audioPlaying = false;
    }



}



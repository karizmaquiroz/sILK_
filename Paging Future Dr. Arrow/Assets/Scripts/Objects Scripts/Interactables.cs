using UnityEngine;





public class Interactables : MonoBehaviour
{

    [SerializeField] private ClipboardData noteData = null;

    public void ShowNote()
    {
        ClipboardController.instance.CurrentNoteSource = ClipboardController.NoteSource.World;
        ClipboardController.instance.ShowNote(noteData);
    }



}

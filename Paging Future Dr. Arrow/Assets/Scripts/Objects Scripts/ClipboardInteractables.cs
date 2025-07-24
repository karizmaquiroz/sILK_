using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClipboardInteractables : MonoBehaviour
{
    [SerializeField] private ClipboardData noteData = null;

    public void ShowNote()
    {
        ClipboardController.instance.CurrentNoteSource = ClipboardController.NoteSource.World;
        ClipboardController.instance.ShowNote(noteData);
    }
}

using UnityEngine;

public class ClipboardInputManager : MonoBehaviour
{
    [Header("Clipboard Pickup Input")]
    public KeyCode interactKey;
    public KeyCode closeKey;
    public KeyCode reverseKey;


    [Header("Should persist?")]
    [SerializeField] private bool persistAcrossScenes = true;

    public static ClipboardInputManager instance;

    /// <summary>
    /// INPUTS FOR THIS SYSTEM ARE LOCATED IN: NoteInteractor and each Note controller script
    /// </summary>

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
}

using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ClipboardData", menuName = "Scriptable Objects/ClipboardData", order = 1)]
public class ClipboardData : ScriptableObject
{
    [SerializeField] private string noteID = null;
    [SerializeField] private string noteName = null;
    [SerializeField] private Sprite noteIcon = null;
    [SerializeField] private bool addToInventory = false;

    [SerializeField] private Sprite[] pageImages = null;
    [SerializeField] private Vector2 pageScale = new Vector2(900, 900);

    [SerializeField] private bool showTextOnMainPage = false;
    [SerializeField] private bool showNavigationButtons = false;
    [TextArea(4, 8)][SerializeField] private string[] pageText = new string[] { "Null" };

    [SerializeField] private Vector2 mainTextAreaScale = new Vector2(495, 795);
    [SerializeField] private int mainTextSize = 25;
    [SerializeField] private TMP_FontAsset mainFontAsset = null;
    [SerializeField] private Color mainFontColor = Color.black;

    [SerializeField] private bool enableOverlayText = false;
    [SerializeField] private bool showOverlayOnOpen = false;
    [SerializeField] private Color overlayBGColor = Color.white;
    [SerializeField] private Vector2 overlayTextAreaScale = new Vector2(1045, 300);
    [SerializeField] private Vector2 overlayTextBGScale = new Vector2(1160, 300);

    [SerializeField] private int overlayTextSize = 25;
    [SerializeField] private TMP_FontAsset overlayFontAsset = null;
    [SerializeField] private Color overlayFontColor = Color.black;

   

    [SerializeField] private bool isNoteTrigger = false;

    public string NoteID => noteID;
    public string NoteName => noteName;
    public Sprite NoteIcon => noteIcon;
    public bool AddToInventory => addToInventory;
    public Sprite[] PageImages => pageImages;
    public Vector2 PageScale => pageScale;
    public bool ShowTextOnMainPage => showTextOnMainPage;
    public bool ShowNavigationButtons => showNavigationButtons;
    public string[] PageText => pageText;
    public Vector2 MainTextAreaScale => mainTextAreaScale;
    public int MainTextSize => mainTextSize;
    public TMP_FontAsset MainFontAsset => mainFontAsset;
    public Color MainFontColor => mainFontColor;
    public bool EnableOverlayText => enableOverlayText;
    public bool ShowOverlayOnOpen => showOverlayOnOpen;
    public Color OverlayBGColor => overlayBGColor;
    public Vector2 OverlayTextAreaScale => overlayTextAreaScale;
    public Vector2 OverlayTextBGScale => overlayTextBGScale;
    public int OverlayTextSize => overlayTextSize;
    public TMP_FontAsset OverlayFontAsset => overlayFontAsset;
    public Color OverlayFontColor => overlayFontColor;
    
    
    public bool IsNoteTrigger => isNoteTrigger;
}

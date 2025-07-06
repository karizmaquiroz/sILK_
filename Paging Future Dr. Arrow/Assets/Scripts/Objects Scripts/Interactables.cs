using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;
using Text = UnityEngine.UI.Text;





public class Interactables : MonoBehaviour
{

    public GameObject interaction_debrief_UI; //ref to Canvas or Text parent
    private Text interaction_text; //ref to the Text element
    private Text interaction_Debrief_Text;//ref to the text element (debrief text/notes on BMT)

    //npc dialogue interactions
    [SerializeField] private string prompt; // prompt when interacting with object/person such as "read" or "speak"
    [SerializeField] private GameObject uiPanel; // panel for prompt text
    [SerializeField] private TextMeshPro promptText; // in game display of text string
    
    public Conversation convo;
    public bool isDisplayed = false;


    //[SerializeField] GameObject miniGame; //can be a physical 2d object or change to open a minigame scene

    GameObject highlight; //object glows in range so player knows it is grabble/playable


    void Start()
    {
        //get text component if interaction_Debrief_UI is the parent)
        /*
        if (interaction_debrief_UI != null)
        {
            interaction_text = interaction_Debrief_UI.GetComponentInChildren<Text>();
            interaction_Debrief_UI.SetActive(false); //text will be hidden on start

        }
        */
        uiPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (isDisplayed & this.CompareTag("NPC")) {
            if (Input.GetMouseButtonDown(0)) {
                DialogueManager.StartConversation(convo);
            }
        }
    }


    private void OnEnable()
    {
        highlight = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            highlight.SetActive(true);
            SetUp();

            if (interaction_debrief_UI != null)
            {
                interaction_debrief_UI.SetActive(true);//shows the text
                //interaction_.Text = "Press [E} to read Me!";// set the text message

            }

            if (this.CompareTag("NPC")) {
                //interaction_.Text = "Press [E} to read Me!";// set the text message

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            highlight.SetActive(false);
            Close();

            if (interaction_debrief_UI != null)
            {
                interaction_debrief_UI.SetActive(false);//hide the text
    
        }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interaction_Debrief_Text.gameObject.SetActive(true);

        }

    }

    void DisplayPassage()
    {
        //set the debrief text content for the passage
        interaction_Debrief_Text.text = "All Debrief text goes here.";
    }

    public void PlayMiniGame()
    {
        //miniGame.SetActive(true); //if using scene minigame this should be a scene changer
    }

    public void SetUp()
    {
        uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        isDisplayed = false;
    }
}

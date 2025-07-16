using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Text = UnityEngine.UI.Text;





public class Interactables : MonoBehaviour
{
    public GameObject interaction_debrief_UI; //ref to Canvas or Text parent
    private Text interaction_text; //ref to the Text element
    private Text interaction_Debrief_Text;//ref to the text element (debrief text/notes on BMT)


    [SerializeField] GameObject miniGame; //can be a physical 2d object or change to open a minigame scene

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

            if (interaction_debrief_UI != null)
            {
                interaction_debrief_UI.SetActive(true);//shows the text
                //interaction_text.Text = "Press [E} to read Me!";// set the text message

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            highlight.SetActive(false);

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
}

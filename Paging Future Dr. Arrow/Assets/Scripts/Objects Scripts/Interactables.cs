using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Text = UnityEngine.UI.Text;





public class Interactables : MonoBehaviour
{
    public GameObject interaction_debreif_UI; //ref to Canvas or Text parent
    private Text interaction_text; //ref to the Text element
    private Text interaction_Debreif_Text;//ref to the text element (debrief text/notes on BMT)


    [SerializeFeild] GameObject miniGame; //can be a physical 2d object or change to open a minigame scene

    GameObject highlight; //object glows in range so player knows it is grabble/playable


    void start()
    {
        //get text component if interaction_debreif_UI is the parent)
        if (interaction_debrief_UI != null)
        {
            interaction_text = interaction_debreif_UI.GetComponentInChildren<Text>();
            interaction_debreif_UI.SetActive(false); //text will be hidden on start

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

            if (interaction_debreif_UI != null)
            {
                interaction_debreif_UI.SetActive(true);//shows the text
                interaction_.Text = "Press [E} to read Me!";// set the text message

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            highlight.SetActive(false);

            if (interaction_debreif_UI != null)
            {
                interaction_debreif_UI.SetActive(false);//hide the text
    
        }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interaction_Debreif_Text.gameObject.SetActive(true);

        }

    }

    void DisplayPassage()
    {
        //set the debrief text content for the passage
        interaction_Debreif_Text.text = "All Debreif text goes here.";
    }

    public void PlayMiniGame()
    {
        miniGame.SetActive(true); //if using scene minigame this should be a scene changer
    }
}

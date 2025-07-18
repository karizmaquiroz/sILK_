using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogue;

    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Coroutine typing;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public static void StartConversation(Conversation convo)
    {
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.dialogue.text = "";

        instance.ReadNext();
    }

    public void ReadNext()
    {
        if (currentIndex <= currentConvo.GetLength()) {
            
            if (typing == null) {
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
            }
            else {
                instance.StopCoroutine(typing);
                typing = null;
                typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
            }
            currentIndex++;
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;

        while (!complete) {
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);

            if (index == text.Length) {
                yield return new WaitForSecondsRealtime(3f);
                complete = true;
                if (currentIndex <= currentConvo.GetLength()) {
                ReadNext();
                } else {
                    instance.dialogue.text = "";
                }
            }
        }
        typing = null;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ClipButtMan : MonoBehaviour
{
    public GameObject nextButton;

    public void ActivateNext()
    {
       nextButton.SetActive(true);
    }
}

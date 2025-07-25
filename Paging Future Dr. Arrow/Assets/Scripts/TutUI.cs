using Unity.VisualScripting;
using UnityEngine;

public class TutUI : MonoBehaviour
{
    public GameObject screen;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            screen.SetActive(true);
        }
    }
}

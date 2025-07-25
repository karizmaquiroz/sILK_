using System.Collections;
using UnityEngine;

public class TutToMain : MonoBehaviour
{
    public GameObject screen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(wait()); // Start coroutine properly
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        screen.SetActive(true);
    }
}

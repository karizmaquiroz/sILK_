using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Hospital and Narrative");
    }
    public void MiniGame1()
    {
        SceneManager.LoadScene("MiniGameOne");

    }
    public void MiniGame2()
    {
        SceneManager.LoadScene("MG2");

    }
    public void MiniGame3()
    {
        SceneManager.LoadScene("MG3");

    }
}



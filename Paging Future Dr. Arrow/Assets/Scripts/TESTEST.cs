using UnityEngine;
using UnityEngine.SceneManagement;

public class TESTTEST : MonoBehaviour
{
    [Tooltip("Name of the scene to load when button is pressed")]
    public string sceneToLoad;

    public void Change()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is not set in SceneChanger.");
        }
    }
}



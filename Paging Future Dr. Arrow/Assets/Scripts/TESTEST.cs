using UnityEngine;
using UnityEngine.SceneManagement;

public class TESTTEST : MonoBehaviour
{
    [Tooltip("Name of the scene to load when button is pressed")]
    public string sceneToLoad;
    public string otherSceneToLoad;
    public string lastScene;
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
    public void OtherScene() 
    {
        if (!string.IsNullOrEmpty(otherSceneToLoad))
        {
            SceneManager.LoadScene(otherSceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is not set in SceneChanger.");
        }
    }
    public void Final()
    {
        if (!string.IsNullOrEmpty(lastScene))
        {
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogWarning("Scene name is not set in SceneChanger.");
        }
    }
}



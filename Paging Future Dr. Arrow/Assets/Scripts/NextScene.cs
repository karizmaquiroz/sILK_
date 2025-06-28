using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1); //Lead to Game
    }
    public void MiniGame()
    {
        SceneManager.LoadScene(2);
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}

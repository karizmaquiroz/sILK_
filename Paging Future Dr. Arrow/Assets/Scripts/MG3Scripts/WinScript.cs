using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject cells;


    void Start()
    {
        pointsToWin = cells.transform.childCount;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            //win 
            transform.GetChild(0).gameObject.SetActive(true);

            FinishedGame();
        }

    }
    public void FinishedGame()
    {
        SceneManager.LoadScene("Main Menu");
    }


    public void AddPoints()
    {
        currentPoints++;
    }
}

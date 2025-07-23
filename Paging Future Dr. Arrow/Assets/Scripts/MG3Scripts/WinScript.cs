using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
            
        }

    }


    public void AddPoints()
    {
        currentPoints++;
    }
}

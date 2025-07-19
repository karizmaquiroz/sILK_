using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameStates : MonoBehaviour
{
    public static List<GameObject> allCells = new List<GameObject>();
    public GameObject bCell;
    public GameObject sCell;
    public Timer timer;
    private int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StateSet(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeRemaining == 0) {
            StateSet(level++);
        }
    }

    public static int Score()
    {
        int score = 0;
        foreach (var gameObject in allCells) {
            if (gameObject.GetComponent<CellBounce>().GetCType() == "b") {
                score--;
            }
            if (gameObject.GetComponent<CellBounce>().GetCType() == "s") {
                score++;
            }
        }
        return score;
    }

    public void GenerateCells(int numBCells, int numSCells, float speed)
    {
        for (int i = 0; i < numBCells; i++) {
        GameObject instantiatedObject = Instantiate(bCell, new Vector3((i*.4f) + -4f, -3.22f, (i * .4f) + -7.32f), Quaternion.identity) as GameObject;
        instantiatedObject.name = "bCell " + i.ToString();
            instantiatedObject.GetComponent<CellBounce>().velocity = new Vector3(speed, 0f, 0f);
            allCells.Add(instantiatedObject);
        }

        for (int i = 0; i < numSCells; i++) {
            GameObject instantiatedObject = Instantiate(sCell, new Vector3(-1.8f, -3.22f, -7.32f), Quaternion.identity) as GameObject;
            instantiatedObject.name = "sCell " + i.ToString();
            instantiatedObject.GetComponent<CellBounce>().velocity = new Vector3(speed, 0f, 0f);
            allCells.Add(instantiatedObject);
        }
    }
    
    public void StateSet(int lvl){
        foreach (var gameObject in allCells) {
            Destroy(gameObject);
            }
            switch (lvl) {
    case 1:
                GenerateCells(8, 3, 1);
    break;
    case 2:
                timer.timeRemaining = 15;
                timer.timerIsRunning = true;
                GenerateCells(9, 3, 1.5f);
    break;
    case 3:
                timer.timeRemaining = 20;
                timer.timerIsRunning = true;
                GenerateCells(10, 3, 2);
    break;
    }
    }

}

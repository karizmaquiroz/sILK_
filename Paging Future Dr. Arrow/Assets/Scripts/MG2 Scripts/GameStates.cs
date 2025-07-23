using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    public static List<GameObject> allCells = new List<GameObject>();
    public static List<GameObject> allCells2 = new List<GameObject>();
    public static List<GameObject> allCells3 = new List<GameObject>();
    public GameObject bCell;
    public GameObject sCell;
    public Timer timer;
    private int level = 0;
    private bool scoreChecked;
    private bool gameisrunning;

    //ui
    public TMP_Text scoreDisplay;
    private int currentScore = 0;

    public GameObject nextbutton;
    public GameObject vial;
    private Animation vialAnimation;

    public GameObject stars1;
    public GameObject stars2;
    public GameObject stars3;
    public GameObject returnButton;

    void Awake()
    {
        vialAnimation = vial.GetComponent<Animation>();
        nextbutton.SetActive(false);
        returnButton.SetActive(false);
        gameisrunning = true;
        scoreChecked = false;
        stars1.SetActive(false);
        stars2.SetActive(false);
        stars3.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer.timeRemaining == 0) {
            gameisrunning = false;
            currentScore = Score(currentScore);
            scoreDisplay.text = currentScore.ToString();  
        }
        else {
            gameisrunning = true;
        }
        //Debug.Log(level + "is running" + gameisrunning + " is checked" + scoreChecked + timer.timeRemaining);
    }

    public int Score(int score)
    {
        if (!gameisrunning && !scoreChecked) {
            switch (level) {
                case 1:
                    foreach (var gameObject in allCells) {
                        if (gameObject.GetComponent<CellBounce>().GetCType() == "b" && gameObject.GetComponent<CellBounce>().state == true) {
                            score--;
                        }
                        if (gameObject.GetComponent<CellBounce>().GetCType() == "s" && gameObject.GetComponent<CellBounce>().state == true) {
                            score++;
                        }
                    }
                    break;
                case 2:
                    foreach (var gameObject in allCells2) {
                        if (gameObject.GetComponent<CellBounce>().GetCType() == "b" && gameObject.GetComponent<CellBounce>().state == true) {
                            score--;
                        }
                        if (gameObject.GetComponent<CellBounce>().GetCType() == "s" && gameObject.GetComponent<CellBounce>().state == true) {
                            score++;
                        }
                    }
                    break;
                case 3:
                    foreach (var gameObject in allCells3) {
                        if (gameObject.GetComponent<CellBounce>().GetCType() == "b" && gameObject.GetComponent<CellBounce>().state == true) {
                            score--;
                        }
                        if (gameObject.GetComponent<CellBounce>().GetCType() == "s" && gameObject.GetComponent<CellBounce>().state == true) {
                            score++;
                        }
                    }
                    break;
            }
            scoreChecked = true;
            
            if (level < 3) { 
            nextbutton.SetActive(true);
            } else {
                if (score < 4) {
                stars1.SetActive(true);
                }
                if (score > 3 && score < 7) {
                    stars1.SetActive(true);
                    stars2.SetActive(true);
                }
                if (score > 8) {
                    stars1.SetActive(true);
                    stars2.SetActive(true);
                    stars3.SetActive(true);
                }
                returnButton.SetActive(true);
            }
        }

        return score;
    }

    public void GenerateCells(int round, int numBCells, int numSCells, float speed)
    {
        switch (round) {
            case 1:
                for (int i = 0; i < numBCells; i++) {
                    GameObject instantiatedObject = Instantiate(bCell, new Vector3((i * .4f) + -4f, -3.22f, (i * .4f) + -7.32f), Quaternion.identity) as GameObject;
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
                break;
            case 2:
                for (int i = 0; i < numBCells; i++) {
                    GameObject instantiatedObject = Instantiate(bCell, new Vector3((i * .4f) + -4f, -3.22f, (i * .4f) + -7.32f), Quaternion.identity) as GameObject;
                    instantiatedObject.name = "bCell " + i.ToString();
                    instantiatedObject.GetComponent<CellBounce>().velocity = new Vector3(speed, 0f, 0f);
                    allCells2.Add(instantiatedObject);
                }

                for (int i = 0; i < numSCells; i++) {
                    GameObject instantiatedObject = Instantiate(sCell, new Vector3(-1.8f, -3.22f, -7.32f), Quaternion.identity) as GameObject;
                    instantiatedObject.name = "sCell " + i.ToString();
                    instantiatedObject.GetComponent<CellBounce>().velocity = new Vector3(speed, 0f, 0f);
                    allCells2.Add(instantiatedObject);
                }
                break;
            case 3:
                for (int i = 0; i < numBCells; i++) {
                    GameObject instantiatedObject = Instantiate(bCell, new Vector3((i * .4f) + -5f, -3.22f, (i * .4f) + -7.32f), Quaternion.identity) as GameObject;
                    instantiatedObject.name = "bCell " + i.ToString();
                    instantiatedObject.GetComponent<CellBounce>().velocity = new Vector3(speed, 0f, 0f);
                    allCells3.Add(instantiatedObject);
                }

                for (int i = 0; i < numSCells; i++) {
                    GameObject instantiatedObject = Instantiate(sCell, new Vector3(-1.8f, -3.22f, -7.32f), Quaternion.identity) as GameObject;
                    instantiatedObject.name = "sCell " + i.ToString();
                    instantiatedObject.GetComponent<CellBounce>().velocity = new Vector3(speed, 0f, 0f);
                    allCells3.Add(instantiatedObject);
                }
                break;
        }
    }

    public void StateSet()
    {
        timer.timeRemaining = 10;
        timer.timerIsRunning = true;
        switch (level) {
            case 0:
                GenerateCells(1, 8, 3, 1);
                break;
            case 1:
                GenerateCells(2, 9, 3, 1.5f);
                break;
            case 2:
                GenerateCells(3, 10, 3, 2);
                break;
        }
    }

    public void NextLevel()
    {
        nextbutton.SetActive(false);
        vialAnimation.Play("MG2_BVMovement2");
        gameisrunning = true;
        if (scoreChecked == true) {
            if (level == 1) {
                foreach (var gameObject in allCells) {
                    Destroy(gameObject);
                }
            }
            else if (level == 2) {
                foreach(var gameObject in allCells2) {
                    Destroy(gameObject);
                }
            } else if (level == 3) {
                foreach (var gameObject in allCells3) {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void LevelStart()
    {
        StateSet();
        level++;
        vialAnimation.Play("MG2_BVMovement");
        scoreChecked = false;
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Hospital and Narrative");
    }
}

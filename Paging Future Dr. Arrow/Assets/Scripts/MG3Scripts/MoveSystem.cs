using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSystem : MonoBehaviour
{
    [SerializeField]
    public Transform correctForm; //GameObject

    private Vector2 initialPosition;



    private bool moving;
    private bool finish;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;


    private void Start()
    {
        //resetPosition = this.transform.localPosition;
        initialPosition = transform.position;
    }

    private void Update()
    {
        /*
        if (finish == false)
        {

            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }
        */
        if (Input.touchCount > 0 && !finish)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        startPosX = touchPos.x - transform.position.x;
                        startPosY = touchPos.y - transform.position.y;

                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        this.gameObject.transform.position = new Vector2(touchPos.x - startPosX, touchPos.y - startPosY);

                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - correctForm.transform.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - correctForm.transform.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(correctForm.position.x, correctForm.position.y); // Vector 3 (...correctForm.transform.position.z);
                        finish = true;

                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                        // Vector 3 (...resetPosition.z);
                        
                    }
                    break;

            }


            /*
            private void OnMouseDown()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePos;
                    mousePos = Input.mousePosition;
                    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                    startPosX = mousePos.x - this.transform.localPosition.x;
                    startPosY = mousePos.y - this.transform.localPosition.y;



                    moving = true;

                }
            }
            private void OnMouseUp() 
            {
                moving = false;

                if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f && 
                    Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
                {
                    this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform .position.z);
                    finish = true;


                    //points system calls from scripts from other points
                      GameObject.Find("PointHandler").GetComponent<WinScript>().AddPoints();
                }
                else
                {
                    this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
                }
            }


        */


        }
    }
}
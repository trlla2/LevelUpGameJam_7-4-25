using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Drag : MonoBehaviour
{


    [SerializeField] private GameObject correctForm;
    private bool moving, finish;

    private float startPosX, startPosY;

    private BoxCollider2D coll;


    [SerializeField] private float snapPuzzle = 1.5f;

    private TMP_Text text;

 
    void Start()
    {
        
        coll = GetComponent<BoxCollider2D>();
        text = GetComponent<TMP_Text>();

    }
    // Update is called once per frame
    void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
            Debug.Log("Moving");
        }
    }
    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.position.x - correctForm.transform.position.x) <= snapPuzzle &&
            Mathf.Abs(this.transform.position.y - correctForm.transform.position.y) <= snapPuzzle)
        {
            this.transform.position = correctForm.transform.position;
            finish = true;
            if (text != null)
                text.color = Color.white;

          

            //GameObject.Find("WinManager").GetComponent<winCount>().AddPoints();
            //correctForm.SetActive(false);
            coll.enabled = false;

            GetComponent<SC_PlaceDetector>().IsSnaped();

            Debug.Log("Correct");
        }
        
    }


   
}

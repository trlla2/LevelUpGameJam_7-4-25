using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Timer_MiniGame : MonoBehaviour
{
    // Start is called before the first frame update


    private bool Failed;

    [SerializeField]
    private float currentTimer;
    [SerializeField]
    private float timeOfMiniGame;

    private GameObject ThisElement;

    // Update is called once per frame

    private void Awake()
    {
        ThisElement = this.gameObject;
        currentTimer = 0;
        Failed = false;
    }
    private void FixedUpdate()
    {
        if(currentTimer < timeOfMiniGame)
        {
            currentTimer += Time.deltaTime ;
        }
        else if(currentTimer >= timeOfMiniGame)
        {
            Failed = true;
            ThisElement.SetActive(false);
        }
    }

    public void ActivateTimer()
    {
        currentTimer = 0;
        Failed = false;
        ThisElement.SetActive(true);    
    }
    public float GetTimerResult()
    {
        return currentTimer;
    }
    public bool GetIfFilerd()
    {
        return Failed;
    }
}

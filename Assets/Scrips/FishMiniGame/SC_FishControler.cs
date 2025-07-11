using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SC_FishControler : MonoBehaviour
{
    private int PhishCounter;

    private int MaxPhish;

    [Header("events")]
    public UnityEvent ActivateWhenFinish;

    void Start()
    {
        PhishCounter = 0;
        MaxPhish = 3;
    }



    private void SeeIfWin()
    {
        if(PhishCounter >= MaxPhish)
        {
            //victtoria

            ActivateWhenFinish.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    public void addPhsiCounter()
    {
        PhishCounter++;
        SeeIfWin();
    }
}

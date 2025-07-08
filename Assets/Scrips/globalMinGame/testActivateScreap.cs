using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testActivateScreap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject TestElementi;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
           // TestElementi.SetActive(true);
            TestElementi.GetComponent<SC_Timer_MiniGame>().ActivateTimer();
           
        }
    }
}

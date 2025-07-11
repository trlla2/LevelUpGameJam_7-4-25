using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_RAndomPosition : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 randomPositions;

    [SerializeField]
    private float top, botom, left, right;


    void Start()
    {
        randomPositions = new Vector3(Random.Range(left, right), Random.Range(top, botom), 0);
        this.transform.position = randomPositions;
    }

   
}

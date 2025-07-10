using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPopup : MonoBehaviour
{
    [Header("SETUP")]
    [SerializeField] private int points = 10;
    
    public void OnClick()
    {
        PointsManager.Instance.AddPoints(points);
        Destroy(this.gameObject);
    }
}

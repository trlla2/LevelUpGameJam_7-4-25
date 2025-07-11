using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlaceDetector : MonoBehaviour
{

    private bool snaped;
    // Start is called before the first frame update
    [SerializeField]
    private SC_FishControler fishControler;

    private void Start()
    {
        snaped = false;
       
    }
    public void IsSnaped()
    {
        snaped = true;
        fishControler.addPhsiCounter();
    }
}

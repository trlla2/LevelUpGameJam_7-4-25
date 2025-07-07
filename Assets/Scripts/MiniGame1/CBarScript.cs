using UnityEngine;
using UnityEngine.UI;

public class CBarScript : MonoBehaviour
{
    public float completitionProgress = 0.0f;
    public Slider slider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = completitionProgress;
    }
}

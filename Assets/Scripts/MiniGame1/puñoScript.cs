using UnityEngine;

public class puñoScript : MonoBehaviour
{
    public Animator puñoAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            puñoAnimator.SetTrigger("Golpear");
            FindObjectOfType<CBarScript>().completitionProgress += 0.1f;
        }
    }
}

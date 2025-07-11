using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WriteRandom : MonoBehaviour
{
    [Header("SETUP")]
    [SerializeField][TextArea] private string fullText;
    private int textIndex = 0;

    [SerializeField] private float typingSpeed = 0.1f;
    private float timerTyping= 0;

    [SerializeField] private TextMeshProUGUI tmp;


    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        textIndex = 0;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (timerTyping <= 0)
            {
                timerTyping = typingSpeed;
                textIndex++;

                tmp.text += fullText[textIndex];
            }
        }

        if(timerTyping > 0)
        {
            timerTyping -= Time.deltaTime;
        }
    }

    public void ResetText()
    {
        textIndex = 0;
        timerTyping = 0;
        tmp.text = "";
    }
}

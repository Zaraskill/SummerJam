using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string sentences;
    private int index;
    public float typingSpeed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDisplay(string phrase)
    {
        sentences = phrase;
        textDisplay.text = phrase;
        //StartCoroutine(TypeEffect());
    }

    public void NextSentence()
    {

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeEffect());
        }
        else
        {
            textDisplay.text = "";
        }
    }

    IEnumerator TypeEffect()
    {
        foreach(char letter in sentences)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

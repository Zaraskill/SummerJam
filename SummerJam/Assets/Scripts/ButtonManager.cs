using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private string place;

    public GameObject validation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDestination(string hotel)
    {
        place = hotel;
        validation.SetActive(true);
    }

    public void OnClickValidate(bool choice)
    {
        if (choice)
        {
            if (place == GameManager.instance.goodHotelName)
            {
                GameManager.instance.ResultChoice(true);
            }
            else
            {
                GameManager.instance.ResultChoice(false);
            }
        }
        else
        {
            validation.SetActive(false);
        }
        
    }
}

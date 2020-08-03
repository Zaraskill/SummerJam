using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public string place;

    public GameObject validation;
    public GameObject book;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    public Image pages;
    public GameObject map;
    public GameObject card;
    public GameObject phone;

    public List<Sprite> pagesBook;
    private int indexBook;
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
            map.SetActive(false);
        }
        validation.SetActive(false);
        
        
    }

    public void OnClickDisplayMap(bool display)
    {
        if (display)
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
        
    }

    public void OnClickDisplayCard(bool display)
    {
        if (display)
        {
            card.SetActive(true);
            GameManager.instance.ClientName();
        }
        else
        {
            card.SetActive(false);
        }
        
    }

    public void OnClickDisplayMiniGame()
    {
        if (GameManager.instance.canPlayMiniGame)
        {
            GameManager.instance.NextState(GameManager.STATE.MiniGameState);
        }        
    }

    public void OnClickDisplayBook(bool display)
    {
        if (display)
        {
            book.SetActive(true);
            indexBook = 0;
            pages.sprite = pagesBook[0];
            buttonLeft.SetActive(true);
            buttonRight.SetActive(true);
            if (indexBook == 0)
            {
                buttonLeft.SetActive(false);
            }
            if (indexBook == pagesBook.Count - 1)
            {
                buttonRight.SetActive(false);
            }
        }
        else
        {
            book.SetActive(false);
        }
        
    }

    public void OnClickPageBook(int direction)
    {        
        indexBook += direction;
        pages.sprite = pagesBook[indexBook];
        buttonLeft.SetActive(true);
        buttonRight.SetActive(true);
        if (indexBook == 0)
        {
            buttonLeft.SetActive(false);
        }
        if (indexBook == pagesBook.Count - 1)
        {
            buttonRight.SetActive(false);
        }
    }
}

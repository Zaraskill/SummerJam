﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Start is called before the first frame update
    public enum STATE { InitNewCustomer, CustomerState, MiniGameState, MapState, ConfirmationState, DisplayResultsState}

    [SerializeField]
    private STATE gameState;

    public GameObject map;

    [SerializeField]
    private bool isMiniGameOver = false;
    [SerializeField]
    private bool isChoiceDone = false;

    public List<HotelSettings> hotels;
    public List<RestoSettings> restos;
    public List<string> randomName;
    public Dialog displayDiscussion;

    [HideInInspector] public string goodHotelName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AudioManager.instance.Play("Main_music");
        gameState = STATE.InitNewCustomer;

        if (FirstMiniGameManager.instance != null)
        {
            FirstMiniGameManager.instance.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case STATE.InitNewCustomer:
                Initsentence();
                break;
            case STATE.CustomerState:
                displayDiscussion.StartDisplay(usableSentense);
                break;
            case STATE.MiniGameState:                
                if(isMiniGameOver)
                {
                    gameState = STATE.MapState;
                    isMiniGameOver = false;
                }
                break;
            case STATE.MapState:
                map.SetActive(true);
                if (isChoiceDone)
                {
                    gameState = STATE.ConfirmationState;
                    isChoiceDone = false;
                }
                break;
            case STATE.ConfirmationState:
                break;
            case STATE.DisplayResultsState:
                break;
            default:
                break;
        }
    }

    bool isHotel = false;
    public List<string> sentenseHotel;
    public List<string> sentenseHotelWords;
    public List<string> sentenseHotelRoom;
    public List<string> sentenseResto;
    public List<string> sentenseRestoWords;
    public List<string> sentenseRestoMenu;

    public List<string> sentenseVisual;
    public List<string> sentenseDate;
    public List<string> sentensePrise;
    public List<string> sentenseFake;

    public List<string> fullSentenses = new List<string>();
    private string usableSentense;
    public string sentensToShow = "J'ai rien compris ^^";

    public void Initsentence()
    {
        // chois entre hotel et resto
        isHotel = UnityEngine.Random.Range(0, 2) < 1;

        // chois phrase
        if (isHotel)
        {
            HotelSettings hotel = hotels[UnityEngine.Random.Range(0, hotels.Count)];
            goodHotelName = hotel.name;
            fullSentenses.Add(string.Format(sentenseHotel[UnityEngine.Random.Range(0, sentenseHotel.Count)], sentenseHotelWords[UnityEngine.Random.Range(0, sentenseHotelWords.Count)]));
            fullSentenses.Add(string.Format(sentenseHotelRoom[UnityEngine.Random.Range(0, sentenseHotelRoom.Count)], hotel.rooms[UnityEngine.Random.Range(0, hotel.rooms.Count)]));


            fullSentenses.Add(string.Format(sentenseVisual[UnityEngine.Random.Range(0, sentenseVisual.Count)], hotel.visual));
            fullSentenses.Add(string.Format(sentenseDate[UnityEngine.Random.Range(0, sentenseDate.Count)], hotel.jours[0], hotel.jours[1]));
            fullSentenses.Add(string.Format(sentensePrise[UnityEngine.Random.Range(0, sentensePrise.Count)], hotel.prix));
            fullSentenses.Add(string.Format(sentenseFake[UnityEngine.Random.Range(0, sentenseFake.Count)]));
        }
        else
        {
            RestoSettings resto = restos[UnityEngine.Random.Range(0, restos.Count)];
            goodHotelName = resto.name;
            fullSentenses.Add(string.Format(sentenseResto[UnityEngine.Random.Range(0, sentenseResto.Count)], sentenseRestoWords[UnityEngine.Random.Range(0, sentenseRestoWords.Count)]));
            fullSentenses.Add(string.Format(sentenseRestoMenu[UnityEngine.Random.Range(0, sentenseRestoMenu.Count)], resto.menus[UnityEngine.Random.Range(0, resto.menus.Count)]));


            fullSentenses.Add(string.Format(sentenseVisual[UnityEngine.Random.Range(0, sentenseVisual.Count)], resto.visual));
            fullSentenses.Add(string.Format(sentenseDate[UnityEngine.Random.Range(0, sentenseDate.Count)], resto.jours[0], resto.jours[1]));
            fullSentenses.Add(string.Format(sentensePrise[UnityEngine.Random.Range(0, sentensePrise.Count)], resto.prix));
            fullSentenses.Add(string.Format(sentenseFake[UnityEngine.Random.Range(0, sentenseFake.Count)]));
        }


        // randomiser l'array

        usableSentense = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", fullSentenses[0], fullSentenses[1], fullSentenses[2], fullSentenses[3], fullSentenses[4], fullSentenses[5]);

        NextState();
    }

    public void DecriptString(bool[] words)
    {
        string[] fieldSeparator = { " ", ".", ",", "?", "!" , "\n"};
        string[] wordsList = usableSentense.Split(fieldSeparator, StringSplitOptions.RemoveEmptyEntries);
        sentensToShow = usableSentense;

        for (int i = 0; i < words.Length; i++)
        {
            if (!words[i])
            {
                sentensToShow = sentensToShow.Replace(" "+wordsList[i] + " ", " " + "XXX" + " ");
                sentensToShow = sentensToShow.Replace(" "+wordsList[i] + ".", " "+ "XXX" + ".");
                sentensToShow = sentensToShow.Replace(" "+wordsList[i] + ",", " "+"XXX" + ",");
                sentensToShow = sentensToShow.Replace(" "+wordsList[i] + "?", " "+"XXX" + "?");
                sentensToShow = sentensToShow.Replace(" "+wordsList[i] + "!", " "+"XXX" + "!");
                sentensToShow = sentensToShow.Replace(" "+wordsList[i], "XXX");
                sentensToShow = sentensToShow.Replace("X"+wordsList[i] + " ", "X" + "XXX" + " ");
                sentensToShow = sentensToShow.Replace("X"+wordsList[i] + ".", "X"+ "XXX" + ".");
                sentensToShow = sentensToShow.Replace("X"+wordsList[i] + ",", "X"+"XXX" + ",");
                sentensToShow = sentensToShow.Replace("X"+wordsList[i] + "?", "X"+"XXX" + "?");
                sentensToShow = sentensToShow.Replace("X"+wordsList[i] + "!", "X"+"XXX" + "!");
                sentensToShow = sentensToShow.Replace("X"+wordsList[i], "XXXX");
                sentensToShow = sentensToShow.Replace("!" + wordsList[i] + " ", "!" + "XXX" + " ");
                sentensToShow = sentensToShow.Replace("!" + wordsList[i] + ".", "!" + "XXX" + ".");
                sentensToShow = sentensToShow.Replace("!" + wordsList[i] + ",", "!" + "XXX" + ",");
                sentensToShow = sentensToShow.Replace("!" + wordsList[i] + "?", "!" + "XXX" + "?");
                sentensToShow = sentensToShow.Replace("!" + wordsList[i] + "!", "!" + "XXX" + "!");
                sentensToShow = sentensToShow.Replace("!" + wordsList[i], "!XXX");
                sentensToShow = sentensToShow.Replace("." + wordsList[i] + " ", "." + "XXX" + " ");
                sentensToShow = sentensToShow.Replace("." + wordsList[i] + ".", "." + "XXX" + ".");
                sentensToShow = sentensToShow.Replace("." + wordsList[i] + ",", "." + "XXX" + ",");
                sentensToShow = sentensToShow.Replace("." + wordsList[i] + "?", "." + "XXX" + "?");
                sentensToShow = sentensToShow.Replace("." + wordsList[i] + "!", "." + "XXX" + "!");
                sentensToShow = sentensToShow.Replace("." + wordsList[i], ".XXX");
                sentensToShow = sentensToShow.Replace("," + wordsList[i] + " ", "," + "XXX" + " ");
                sentensToShow = sentensToShow.Replace("," + wordsList[i] + ".", "," + "XXX" + ".");
                sentensToShow = sentensToShow.Replace("," + wordsList[i] + ",", "," + "XXX" + ",");
                sentensToShow = sentensToShow.Replace("," + wordsList[i] + "?", "," + "XXX" + "?");
                sentensToShow = sentensToShow.Replace("," + wordsList[i] + "!", "," + "XXX" + "!");
                sentensToShow = sentensToShow.Replace("," + wordsList[i], ",XXX");
                sentensToShow = sentensToShow.Replace("?" + wordsList[i] + " ", "?" + "XXX" + " ");
                sentensToShow = sentensToShow.Replace("?" + wordsList[i] + ".", "?" + "XXX" + ".");
                sentensToShow = sentensToShow.Replace("?" + wordsList[i] + ",", "?" + "XXX" + ",");
                sentensToShow = sentensToShow.Replace("?" + wordsList[i] + "?", "?" + "XXX" + "?");
                sentensToShow = sentensToShow.Replace("?" + wordsList[i] + "!", "?" + "XXX" + "!");
                sentensToShow = sentensToShow.Replace("?" + wordsList[i], "?XXX");
            }
        }
        Debug.Log(sentensToShow);

        gameState = STATE.CustomerState;
    }

    public void ResultChoice(bool win)
    {
        if (win)
        {

        }
        else
        {

        }
        NextState();
    }

    public void NextState()
    {
        gameState = gameState + 1;
        if (gameState == STATE.MiniGameState)
        {
            if (FirstMiniGameManager.instance != null)
            {
                FirstMiniGameManager.instance.gameObject.SetActive(true);
                FirstMiniGameManager.instance.InitCoutdown(usableSentense);
            }
            else
            {
                Debug.LogError("No FirstMiniGameManager");
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Start is called before the first frame update
    public enum STATE { InitNewCustomer, CustomerState, MiniGameState, DisplayResultsState}

    [SerializeField]
    public STATE gameState;
    [SerializeField]
    private int score;

    public List<GameObject> clients;
    public GameObject parentInstance;
    public GameObject client;
    private bool init = true;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI nameClient;
    public TextMeshProUGUI surnameClient;
    public TextMeshProUGUI language;

    [SerializeField]
    private bool isMiniGameOver = false;
    [SerializeField]
    private bool isChoiceDone = false;

    public List<HotelSettings> hotels;
    public List<RestoSettings> restos;
    public List<string> randomName;
    public Dialog displayDiscussion;
    public float timeInSeconds;
    private float timerTimeChoice;
    private bool initTime = false;

    [HideInInspector] public string goodHotelName;
    public Langage langue;


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

    public List<string> fullSentenses;
    private string usableSentense;
    public string sentensToShow = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";




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
                if (init)
                {
                    InstantiateNewClient();
                    Initsentence();
                }                
                break;
            case STATE.CustomerState:
                displayDiscussion.StartDisplay(sentensToShow);
                if (initTime)
                {
                    timerTimeChoice -= Time.deltaTime;
                    if (timerTimeChoice <= 0)
                    {
                        initTime = false;
                    }
                    if (timerTimeChoice <= timeInSeconds * 0.6)
                    {
                        client.GetComponent<Image>().sprite = client.GetComponent<Client>().noReaction;
                    }
                    if (timerTimeChoice <= timeInSeconds * 0.3)
                    {
                        client.GetComponent<Image>().sprite = client.GetComponent<Client>().angry;
                    }
                }                
                break;
            case STATE.MiniGameState:                
                if(isMiniGameOver)
                {
                    timerTimeChoice = timeInSeconds;
                    initTime = true;
                    gameState = STATE.CustomerState;
                    isMiniGameOver = false;
                }
                break;
            case STATE.DisplayResultsState:
                if (!init)
                {
                    sentensToShow = "";
                    displayDiscussion.StartDisplay(sentensToShow);
                    init = true;
                    client.GetComponent<Animator>().SetBool("leaving", true);
                    StartCoroutine("WaitingForLeave");
                }                
                break;
            default:
                break;
        }
    }
    

    public void Initsentence()
    {
        // chois entre hotel et resto
        //isHotel = UnityEngine.Random.Range(0, 2) < 1;
        isHotel = false;
        // chois phrase
        if (isHotel)
        {
            HotelSettings hotel = hotels[UnityEngine.Random.Range(0, hotels.Count)];
            goodHotelName = hotel.name;
            fullSentenses[0] = string.Format(sentenseHotel[UnityEngine.Random.Range(0, sentenseHotel.Count)], "<color=red>"+sentenseHotelWords[UnityEngine.Random.Range(0, sentenseHotelWords.Count)]+"<color=white>");
            fullSentenses[1] = (string.Format(sentenseHotelRoom[UnityEngine.Random.Range(0, sentenseHotelRoom.Count)], "<color=red>" + hotel.rooms[UnityEngine.Random.Range(0, hotel.rooms.Count)] + "<color=white>"));


            fullSentenses[2] = (string.Format(sentenseVisual[UnityEngine.Random.Range(0, sentenseVisual.Count)], "<color=red>" + hotel.visual + "<color=white>"));
            fullSentenses[3] = (string.Format(sentenseDate[UnityEngine.Random.Range(0, sentenseDate.Count)], "<color=red>" + hotel.jours[0] + "<color=white>", "<color=red>" + hotel.jours[1] + "<color=white>"));
            fullSentenses[4] = (string.Format(sentensePrise[UnityEngine.Random.Range(0, sentensePrise.Count)], "<color=red>" + hotel.prix + "<color=white>"));
            fullSentenses[5] = (string.Format(sentenseFake[UnityEngine.Random.Range(0, sentenseFake.Count)]));
            langue = hotel.langages[UnityEngine.Random.Range(0, hotel.langages.Count)];
        }
        else
        {
            RestoSettings resto = restos[UnityEngine.Random.Range(0, restos.Count)];
            goodHotelName = resto.name;
            fullSentenses[0] = (string.Format(sentenseResto[UnityEngine.Random.Range(0, sentenseResto.Count)], "<color=red>" + sentenseRestoWords[UnityEngine.Random.Range(0, sentenseRestoWords.Count)] + "<color=white>"));
            fullSentenses[1] = (string.Format(sentenseRestoMenu[UnityEngine.Random.Range(0, sentenseRestoMenu.Count)], "<color=red>" + resto.menus[UnityEngine.Random.Range(0, resto.menus.Count)] + "<color=white>"));


            fullSentenses[2] = (string.Format(sentenseVisual[UnityEngine.Random.Range(0, sentenseVisual.Count)], "<color=red>" + resto.visual + "<color=white>"));
            fullSentenses[3] = (string.Format(sentenseDate[UnityEngine.Random.Range(0, sentenseDate.Count)], "<color=red>" + resto.jours[0], "<color=red>" + resto.jours[1] + "<color=white>"));
            fullSentenses[4] = (string.Format(sentensePrise[UnityEngine.Random.Range(0, sentensePrise.Count)], "<color=red>" + resto.prix + "<color=white>"));
            fullSentenses[5] = (string.Format(sentenseFake[UnityEngine.Random.Range(0, sentenseFake.Count)]));
            langue = resto.langages[UnityEngine.Random.Range(0, resto.langages.Count)];
        }


        // randomiser l'array

        usableSentense = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", fullSentenses[0], fullSentenses[1], fullSentenses[2], fullSentenses[3], fullSentenses[4], fullSentenses[5]);
        
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

        isMiniGameOver = true;
    }

    public void ResultChoice(bool win)
    {
        if (win)
        {
            if (timerTimeChoice >= timeInSeconds * 0.8)
            {
                score += 5;
            }
            else if (timerTimeChoice < timeInSeconds * 0.8 && timerTimeChoice >= timeInSeconds * 0.6)
            {
                score += 4;
            }
            else if (timerTimeChoice < timeInSeconds * 0.6 && timerTimeChoice >= timeInSeconds * 0.4)
            {
                score += 3;
            }
            else if (timerTimeChoice < timeInSeconds * 0.4 && timerTimeChoice >= timeInSeconds * 0.2)
            {
                score += 2;
            }
            else if (timerTimeChoice < timeInSeconds * 0.2 && timerTimeChoice > 0)
            {
                score += 1;
            }
            else
            {
                score += 0;
            }
        }
        else
        {
            score += 0;
        }
        scoreText.text = score.ToString();
        gameState = STATE.DisplayResultsState;
    }

    public void InstantiateNewClient()
    {
        init = false;
        int random = UnityEngine.Random.Range(0, 4);
        switch (random)
        {
            case 0:
                client = Instantiate(clients[0], parentInstance.transform);
                break;
            case 1:
                client = Instantiate(clients[1], parentInstance.transform);
                break;
            case 2:
                client = Instantiate(clients[2], parentInstance.transform);
                break;
            case 3:
                client = Instantiate(clients[3], parentInstance.transform);
                break;
        }
        StartCoroutine("WaitingForAnim");
    }

    public void NextState(STATE state)
    {
        gameState = state;
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

    public void ClientName()
    {
        nameClient.text = client.GetComponent<Client>().nameClient[1];
        surnameClient.text = client.GetComponent<Client>().nameClient[0];
        language.text = client.GetComponent<Client>().language.ToString();
    }

    IEnumerator WaitingForAnim()
    {
        yield return new WaitForSeconds(2.5f);
        gameState = STATE.CustomerState;
    }

    IEnumerator WaitingForLeave()
    {
        yield return new WaitForSeconds(2.5f);
        gameState = STATE.InitNewCustomer;
        Destroy(client);
        sentensToShow = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
    }

}

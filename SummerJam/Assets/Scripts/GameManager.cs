using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Start is called before the first frame update
    public enum STATE { InitNewCustomer, CustomerState, MiniGameState, MapState, ConfirmationState, DisplayResultsState}

    [SerializeField]
    private STATE gameState;

    public GameObject miniGame;

    [SerializeField]
    private bool isMiniGameOver = false;
    [SerializeField]
    private bool isChoiceDone = false;

    public List<HotelSettings> hotels;
    public List<RestoSettings> restos;

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
        gameState = STATE.InitNewCustomer;

        if (FirstMiniGameManager.instance != null)
        {
            FirstMiniGameManager.instance.gameObject.transform.localScale = Vector3.zero;
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
                break;
            case STATE.MiniGameState:
                miniGame.SetActive(true);
                if(isMiniGameOver)
                {
                    gameState = STATE.MapState;
                    isMiniGameOver = false;
                }
                break;
            case STATE.MapState:
                if(isChoiceDone)
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
    public List<string> sentenseHotelRoom;
    public List<string> sentenseResto;
    public List<string> sentenseRestoMenu;

    public List<string> sentenseVisual;
    public List<string> sentenseDate;
    public List<string> sentensePrise;
    public List<string> sentenseFake;


    public List<string> sentenseHotelWords;
    public List<string> sentenseHotelRoomWords;
    public List<string> sentenseRestoWords;
    public List<string> sentenseRestoMenuWords;

    public List<string> sentenseVisualWords;
    public List<string> sentenseDateWords;
    public List<string> sentensePriseWords;
    public List<string> sentenseFakeWords;

    public List<string> fullSentenses = new List<string>();
    public string usableSentense;

    public void Initsentence()
    {
        // chois entre hotel et resto
        isHotel = Random.Range(0, 2) < 1;

        // chois phrase
        if (isHotel)
        {
            fullSentenses.Add(string.Format(sentenseHotel[Random.Range(0, sentenseHotel.Count)], sentenseHotelWords[Random.Range(0, sentenseHotelWords.Count)]));
            fullSentenses.Add(string.Format(sentenseHotelRoom[Random.Range(0, sentenseHotelRoom.Count)], sentenseHotelRoomWords[Random.Range(0, sentenseHotelRoomWords.Count)]));
        }
        else
        {
            fullSentenses.Add(string.Format(sentenseResto[Random.Range(0, sentenseResto.Count)], sentenseRestoWords[Random.Range(0, sentenseRestoWords.Count)]));
            fullSentenses.Add(string.Format(sentenseRestoMenu[Random.Range(0, sentenseRestoMenu.Count)], sentenseRestoMenuWords[Random.Range(0, sentenseRestoMenuWords.Count)]));
        }

        fullSentenses.Add(string.Format(sentenseHotelWords[Random.Range(0, sentenseHotelWords.Count)], sentenseVisualWords[Random.Range(0, sentenseVisualWords.Count)]));
        fullSentenses.Add(string.Format(sentenseHotelRoomWords[Random.Range(0, sentenseHotelRoomWords.Count)], sentenseDateWords[Random.Range(0, sentenseDateWords.Count)]));
        fullSentenses.Add(string.Format(sentenseRestoWords[Random.Range(0, sentenseRestoWords.Count)], sentensePriseWords[Random.Range(0, sentensePriseWords.Count)]));
        fullSentenses.Add(string.Format(sentenseRestoMenuWords[Random.Range(0, sentenseRestoMenuWords.Count)], sentenseFakeWords[Random.Range(0, sentenseFakeWords.Count)]));

        // randomiser l'array

        usableSentense = string.Format("{0} /n{1}/n{2} /n{3}/n{4} /n{5}/n", fullSentenses[0], fullSentenses[1], fullSentenses[2], fullSentenses[3], fullSentenses[4], fullSentenses[5]);

        NextState();
    }

    public void DecriptString(bool[] words)
    {



        NextState();
    }

    public void NextState()
    {
        gameState = gameState + 1;
        if (gameState == STATE.MiniGameState)
        {
            if (FirstMiniGameManager.instance != null)
            {
                FirstMiniGameManager.instance.gameObject.transform.localScale =Vector3.one;
                FirstMiniGameManager.instance.InitCoutdown(usableSentense);
            }
            else
            {
                Debug.LogError("No FirstMiniGameManager");
            }
        }
    }
}

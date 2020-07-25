using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum STATE { CustomerState, MiniGameState, MapState, ConfirmationState, DisplayResultsState}

    [SerializeField]
    private STATE gameState;

    public GameObject miniGame;

    [SerializeField]
    private bool isMiniGameOver = false;
    [SerializeField]
    private bool isChoiceDone = false;

    void Start()
    {
        gameState = STATE.CustomerState;
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
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

    public void NextState()
    {
        gameState = gameState + 1;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstMiniGameManager : MonoBehaviour
{

    public static FirstMiniGameManager instance;

    public static string[] listNamesMiniGame;

    public GameObject newName;
    public List<GameObject> spawnPoints;
    public float timer;
    public TextMeshPro textMesh;

    private float timerLeft;
    private string[] fieldSeparator = { " " , "."};
    private bool[] checkValidate;
    private string[] namesMiniGame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        timerLeft = timer;
        PrepareListNames("oui");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        timerLeft -= Time.deltaTime;
        textMesh.text = timerLeft.ToString("00.00");
        if (timerLeft <= 0f)
        {
            //END MINIGAME
        }
    }

    public void GenerateName(int spawnPoint)
    {
        int randomName;
        bool present;
        do
        {
            randomName = UnityEngine.Random.Range(0, listNamesMiniGame.Length);
            string word = Array.Find(namesMiniGame, name => name == listNamesMiniGame[randomName]);
            if (word == null)
            {
                present = false;
            }
            else
            {
                present = true;
            }
        } while (checkValidate[randomName] && present);

        GameObject obj = Instantiate(newName, gameObject.transform);
        obj.transform.position = spawnPoints[spawnPoint].transform.position;
        obj.GetComponent<TextMeshPro>().text = listNamesMiniGame[randomName];
    }

    public void GetName()
    {

    }

    public void PrepareListNames(string sentence)
    {
        listNamesMiniGame = sentence.Split(fieldSeparator, StringSplitOptions.RemoveEmptyEntries);
        namesMiniGame = listNamesMiniGame;
        checkValidate = new bool[listNamesMiniGame.Length];
        for(int index = 0 ; index < listNamesMiniGame.Length ; index++)
        {
            checkValidate[index] = false;
        }
        GenerateName(0);
    }
}

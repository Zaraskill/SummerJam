﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstMiniGameManager : MonoBehaviour
{

    public static FirstMiniGameManager instance;

    public static bool canStart;

    public string[] listNamesMiniGame;

    public GameObject newName;
    public List<GameObject> spawnPoints;
    public float timer;
    public TextMeshPro textMesh;
    public TextMeshPro countdownStart;
    public int numberWords;

    private float timerStart = 4f;
    private float timerLeft;
    private string[] fieldSeparator = { " " , "."};
    private bool[] checkValidate;
    private List<string> namesMiniGame;
    private List<int> spawnUse;
    private List<SpawnName> points;
    private List<string> wordsInGame;

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
        spawnUse = new List<int>();
        points = new List<SpawnName>();
        wordsInGame = new List<string>();
        InitCoutdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canStart)
        {
            
            timerStart -= Time.deltaTime;
            countdownStart.text = timerStart.ToString("0");
            if (timerStart <= 0)
            {
                countdownStart.gameObject.SetActive(false);
                canStart = !canStart;
                timerStart = 3f;
                PrepareListNames("oui je suis l'enfant de la vierge et j'apporte une paix dans le monde");
            }
        }
        else
        {
            UpdateTime();
        }        
    }

    private void UpdateTime()
    {
        timerLeft -= Time.deltaTime;
        textMesh.text = timerLeft.ToString("00.00");
        if (timerLeft <= 0f)
        {
            EndGame();
        }
    }

    public void GenerateName()
    {
        int randomName;
        int randomSpawn;

        while (true)
        {
            randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Count);

            if (!spawnUse.Contains(randomSpawn))
            {
                spawnUse.Add(randomSpawn);
                break;
            }         
        }
        while (true)
        {
            randomName = UnityEngine.Random.Range(0, namesMiniGame.Count);
            if (!wordsInGame.Contains(namesMiniGame[randomName]))
            {
                wordsInGame.Add(namesMiniGame[randomName]);
                GameObject obj = Instantiate(newName, gameObject.transform);
                obj.transform.position = spawnPoints[randomSpawn].transform.position;
                obj.GetComponent<TextMeshPro>().text = namesMiniGame[randomName];
                break;
            }
        }     
        points.Add(new SpawnName(randomSpawn, namesMiniGame[randomName]));
    }

    public void GetName(GameObject word)
    {        
        string wordFind = word.GetComponent<TextMeshPro>().text;
        int index = Array.FindIndex(listNamesMiniGame, wornd => wornd == wordFind);
        checkValidate[index] = true;
        wordsInGame.Remove(wordFind);
        namesMiniGame.Remove(wordFind);
        int spawn = points.Find(point => point.word == wordFind).spawnPoint;
        spawnUse.Remove(spawn);               
        Destroy(word);   
        if (namesMiniGame.Count == 0)
        {
            EndGame();
        }
        else if (namesMiniGame.Count >= numberWords)
        {
            GenerateName();
        }
    }

    public void PrepareListNames(string sentence)
    {
        listNamesMiniGame = sentence.Split(fieldSeparator, StringSplitOptions.RemoveEmptyEntries);
        namesMiniGame = new List<string>(listNamesMiniGame);
        checkValidate = new bool[listNamesMiniGame.Length];
        for(int index = 0 ; index < listNamesMiniGame.Length ; index++)
        {
            checkValidate[index] = false;
        }
        for (int index = 0; index < numberWords ; index++)
        {
            GenerateName();
        }
    }

    public void EndGame()
    {
        canStart = false;
        gameObject.SetActive(false);
    }

    private void InitCoutdown()
    {
        timerStart = 3f;
        countdownStart.gameObject.SetActive(true);
    }
}

public struct SpawnName
{
    public int spawnPoint;
    public string word;

    public SpawnName(int point, string s)
    {
        spawnPoint = point;
        word = s;
    }
}

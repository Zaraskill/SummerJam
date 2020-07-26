using System;
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
    private string[] fieldSeparator = { " " , ".", ",", "?", "!", "\n"};
    private bool[] checkValidate;
    private List<string> namesMiniGame;
    public List<int> spawnUse;
    public List<SpawnName> points;
    private List<string> wordsInGame;
    private string phrasing;

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
                PrepareListNames(phrasing);
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

        do
        {
            randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Count);
        } while (spawnUse.Contains(randomSpawn));
        spawnUse.Add(randomSpawn);
        do
        {
            randomName = UnityEngine.Random.Range(0, namesMiniGame.Count);
        } while (wordsInGame.Contains(namesMiniGame[randomName]));

        wordsInGame.Add(namesMiniGame[randomName]);
        GameObject obj = Instantiate(newName, gameObject.transform);
        obj.transform.position = spawnPoints[randomSpawn].transform.position;
        obj.GetComponent<TextMeshPro>().text = namesMiniGame[randomName];

        points.Add(new SpawnName(randomSpawn, namesMiniGame[randomName]));
    }

    public void GetName(GameObject word)
    {        
        string wordFind = word.GetComponent<TextMeshPro>().text;
        int index = Array.FindIndex(listNamesMiniGame, wornd => wornd == wordFind);
        checkValidate[index] = true;
        wordsInGame.Remove(wordFind);
        namesMiniGame.Remove(wordFind);
        SpawnName spawn = points.Find(point => point.word == wordFind);
        spawnUse.Remove(spawn.spawnPoint);
        points.Remove(spawn);
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
        GameManager.instance.DecriptString(checkValidate);
        gameObject.SetActive(false);
    }

    public void InitCoutdown(string sentence)
    {
        timerStart = 3f;
        countdownStart.gameObject.SetActive(true);
        phrasing = sentence;

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

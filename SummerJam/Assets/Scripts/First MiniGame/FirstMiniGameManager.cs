using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstMiniGameManager : MonoBehaviour
{

    public static FirstMiniGameManager instance;

    public string[] listNamesMiniGame;

    public GameObject newName;
    public List<GameObject> spawnPoints;
    public float timer;
    public TextMeshPro textMesh;

    private float timerLeft;
    private string[] fieldSeparator = { " " , "."};
    private bool[] checkValidate;
    public List<string> namesMiniGame;
    private bool[] spawnUse;

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
        spawnUse = new bool[spawnPoints.Count];
        PrepareListNames("oui je suis l'enfant de la vierge et j'apporte la paix dans le monde");
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

    public void GenerateName()
    {
        int randomName;
        bool present;
        int randomSpawn;
        do
        {
            randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Count);
            randomName = UnityEngine.Random.Range(0, listNamesMiniGame.Length);
            string word = namesMiniGame.Find(name => name == listNamesMiniGame[randomName]);
            if (word == "")
            {
                present = false;
            }
            else
            {
                present = true;
            }
        } while (checkValidate[randomName] && present && !spawnUse[randomSpawn]);

        GameObject obj = Instantiate(newName, gameObject.transform);
        obj.transform.position = spawnPoints[randomSpawn].transform.position;
        obj.GetComponent<TextMeshPro>().text = listNamesMiniGame[randomName];
        namesMiniGame.Remove(listNamesMiniGame[randomName]);
        spawnUse[randomSpawn] = true;
    }

    public void GetName(GameObject word)
    {
        string wordFind = word.GetComponent<TextMeshPro>().text;
        int index = Array.FindIndex(listNamesMiniGame, wornd => wornd == wordFind);
        checkValidate[index] = true;
        Destroy(word);
        if (namesMiniGame.Count == 0)
        {

        }
        else
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
        GenerateName();
        GenerateName();
    }
}

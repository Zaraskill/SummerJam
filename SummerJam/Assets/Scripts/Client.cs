using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{

    public Sprite noReaction;
    public Sprite angry;

    public string[] nameClient;
    public Langage language;
    public string[] fieldSeparator = {" "};

    // Start is called before the first frame update
    void Start()
    {
        nameClient = GameManager.instance.randomName[UnityEngine.Random.Range(0, GameManager.instance.randomName.Count)].Split(fieldSeparator, StringSplitOptions.None); ;
        language = GameManager.instance.langue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

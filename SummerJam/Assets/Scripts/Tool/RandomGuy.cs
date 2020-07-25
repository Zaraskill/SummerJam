using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WordIdee
{
    public string name;
    public List<string> deriveryWords;
}

[System.Serializable]
public struct TypeServis
{
    public string name;
    public List<WordIdee> termes;
    public bool isChoise;
}

public class RandomGuy : MonoBehaviour
{
    public List<TypeServis> guyNesecities;
    private List<string> nesecity = new List<string>();

    private void Start()
    {
        CreateRandomGuy();
    }

    public void CreateRandomGuy()
    {
        for (int i = guyNesecities.Count; i-- > 0;)
        {

        }

        for (int i = guyNesecities.Count; i-- > 0;)
        {
            if (guyNesecities[i].termes.Count <= 0)
            {
                return;
            }

            int rand = Random.Range(0, guyNesecities[i].termes.Count);

            nesecity.Add(guyNesecities[i].termes[rand].deriveryWords[Random.Range(0, guyNesecities[i].termes[rand].deriveryWords.Count)]);
        }

        for (int i = nesecity.Count; i-- > 0;)
        {
            Debug.Log(nesecity[i]);
        }
    }
}
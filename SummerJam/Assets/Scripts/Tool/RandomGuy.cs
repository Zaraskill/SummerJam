using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum Prix
{
    Faible,
    Moyen,
    Cher,
}

public enum Visuel
{
    Ancien,
    Moderne,
    Atypique,
}

public enum Hotel
{
    Amoureux,
    Seul,
    Duo,
    Sous_marine,
    Familiale,
    Cinema,
    Pyramide,
    Moyen_Age,
    Préhistoire,
    ScienceFiction,
    Sport,
    Zoo,
    Luxe,
}

public enum Menu
{
    Végétarien,
    Marin,
    Carnivore,
    SurpriseChef,
    Découverte, 
    Enfant,
    Gourmand,
    Vegan,
    SansGluten,
    SansPorc,
    Exotique,
    floral,
    MaxiBestOfPlus,
}

public enum Langqge
{
    Isou,
    Apotrick,
    Topipozo,
    MarABoute,
    TopineEnBoir,
    ClafOuti,
    PateEpourcha,
    ChiPolata,
}*/

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
    private List<string> nesecity;

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
            //nesecity.Add(guyNesecities[i].derivery[Random.Range(0, guyNesecities[i].derivery.Count)]);

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

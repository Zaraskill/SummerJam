using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Prix
{
    haut,
    moyen,
    bas,
}

[System.Serializable]
public enum Jour
{
    lundi,
    mardi,
    mercredi,
    jeudi,
    vendredi,
    samedi,
    dimanche
}

[System.Serializable]
public enum Visual
{
    Ancient,
    Modern,
    Atypique,
}

[System.Serializable]
public enum Langage
{
    Isou,
    Apotrick,
    Topipozo,
    Mar_a_boote,
    Topine_en_Bour,
    Claf_Outi,
    Pate_epourcha,
    Chi_Polata
}

[System.Serializable]
public enum Menu
{
    Vegetarian,
    Sea,
    Carnivorous,
    Surprise_of_the_Chef,
    Discovery,
    Child,
    Gourmet,
    Vegan,
    Gluten_Free,
    Pork_Free,
    Exotic,
    Floral,
    Maxi_Best_of_Plus
}

[System.Serializable]
public enum Room
{
    Love,
    Submarine,
    Family,
    Cinema,
    Pyramid,
    Medieval,
    Prehistory,
    SF,
    Sport,
    Zoo,
    Luxary
}

[CreateAssetMenu(menuName = "Hotel Setting")]
public class HotelSettings : ScriptableObject
{
    public Prix prix;
    public Visual visuals;
    public List<Room> rooms;

    public List<Langage> langages;
    public List<Jour> jours;
}

[CreateAssetMenu(menuName = "Resto Setting")]
public class RestoSettings : ScriptableObject
{
    public Prix prix;
    public Visual visuals;
    public List<Menu> menus;

    public List<Langage> langages;
    public List<Jour> jours;
}

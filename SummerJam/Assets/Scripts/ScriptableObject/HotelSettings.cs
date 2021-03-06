﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Prix
{
    expensive,
    medium,
    cheap,
}

[System.Serializable]
public enum Jour
{
    monday,
    tuesday,
    wednesday,
    thursday,
    friday,
    saturday,
    sunday
}

[System.Serializable]
public enum Visual
{
    Ancient,
    Modern,
    Atypical,
}

[System.Serializable]
public enum Langage
{
    Isou,
    Apotrick,
    Tropipozo,
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
    public Visual visual;
    public List<Room> rooms;

    public List<Langage> langages;
    public List<Jour> jours;
}



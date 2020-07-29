using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resto Setting")]
public class RestoSettings : ScriptableObject
{
    public Prix prix;
    public Visual visual;
    public List<Menu> menus;

    public List<Langage> langages;
    public List<Jour> jours;
}

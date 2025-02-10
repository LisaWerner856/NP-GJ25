using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite image;

    public int manaCost;
    public int damage;

    public void PrintInfo()
    {
        Debug.Log($"This card is: {name}. It costs {manaCost} and does {damage} damage!");
    }
}

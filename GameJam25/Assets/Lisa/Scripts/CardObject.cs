using UnityEngine;

public class CardObject : MonoBehaviour
{
    public Card card;

    // Reference UI elements on the card


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        card.PrintInfo();
    }
}

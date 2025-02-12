using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardObject : MonoBehaviour
{
    public Card card;

    // Reference UI elements on the card
    public Image image;
    public TMP_Text cardName;
    public TMP_Text cardDescription;
    public TMP_Text cardDamage;
    public TMP_Text cardMana;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardName.text = card.name;
        cardDescription.text = card.description;
        cardDamage.text = card.damage.ToString();
        cardMana.text = card.manaCost.ToString();
    } 


    // TODO: add function with effect (ex. increase player health)
}

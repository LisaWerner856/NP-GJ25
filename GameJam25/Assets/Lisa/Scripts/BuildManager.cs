using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BuildManager : MonoBehaviour
{
    public GameObject playerReference; // Player reference, to apply the card effects to.

    public Tilemap tilemap;
    public List<GameObject> cardLibrary; //This will hold the card prefabs that can be spawned.
    public List<BuildingCard> cards;


    [SerializeField] private int selectedCard = 0; // this should be based on the cards in the inventory later.

    public Transform cardGridUI;
    public GameObject tilePreview;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddCardToList(cardLibrary[0]);
        AddCardToList(cardLibrary[1]);
        AddCardToList(cardLibrary[2]);
    }
    private void Update()
    {
        if (tilePreview != null)
        {
            tilePreview.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilePreview.transform.position = new Vector3(tilePreview.transform.position.x, tilePreview.transform.position.y, 0f);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                tilemap.SetTile(tilemap.WorldToCell(position), cards[selectedCard].GetComponent<BuildingCard>().buildingTile);

                // Remove the card from the inventory and update UI
                RemoveCardFromList(selectedCard);

                // Remove the tile from the preview.
                Destroy(tilePreview);
            }
        }
    }

    public void AddCardToList(GameObject card)
    {
        BuildingCard newCard = card.GetComponent<BuildingCard>();
        newCard.cardIndex = cards.Count;
        cards.Add(newCard);

        // draw cards to UI
        GameObject UICard = Instantiate(card);
        UICard.transform.SetParent(cardGridUI);
        UICard.transform.localScale = new Vector3(1f, 1f, 1f);
        
        UpdateCardsList();

    }

    public void UpdateCardsList()
    {
        // go through all cards and update their index
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].cardIndex = i;
        }
    }

    public void PreviewCard(Vector3 position)
    {
        Debug.Log("Previewing card!");
        // Create the tile preview
        tilePreview = new GameObject("TilePreview");
        tilePreview.transform.position = position;

        // Set up the tile preview sprite renderer (optional)
        SpriteRenderer renderer = tilePreview.AddComponent<SpriteRenderer>();
        renderer.sprite = cards[selectedCard].GetComponent<BuildingCard>().buildingTile.sprite;  // Assuming buildingTile has a sprite
    }

    public void PlaceCard(int index)
    {
        selectedCard = index;
        if (tilePreview == null)
        {
            PreviewCard(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        Debug.Log("Placing card!");

    }

    //// These are hardcoded card effects, they go into place card later.
    //    //if (cards[selectedCard].GetComponent<BuildingCard>().buildingCardSO.buildingName == "Forest")
    //    //{
    //    //    cards[selectedCard].GetComponent<BuildingCard>().CardEffectForest(playerReference);
    //    //}
    //    //else if (cards[selectedCard].GetComponent<BuildingCard>().buildingCardSO.buildingName == "Mountain")
    //    //{
    //    //    cards[selectedCard].GetComponent<BuildingCard>().CardEffectMountain(playerReference);
    //    //}
    //    //else if (cards[selectedCard].GetComponent<BuildingCard>().buildingCardSO.buildingName == "Water")
    //    //{
    //    //    cards[selectedCard].GetComponent<BuildingCard>().CardEffectWater(playerReference);
    //    //}

    public void RemoveCardFromList(int selectedCardIndex)
    {
        Debug.Log($"Trying to remove {cards[selectedCard]}");
        // remove gameobject at card pannel.
        GameObject cardToRemove = cardGridUI.GetChild(selectedCard).gameObject;
        Destroy(cardToRemove);
        cards.Remove(cards[selectedCard]);
        //UpdateCardsList();

    }

    //public void RemoveCardFromList(int cardIndex)
    //{
    //    // Remove the card from both the cards list and the UI list
    //    if (cardIndex >= 0 && cardIndex < cards.Count)
    //    {
    //        cards.RemoveAt(cardIndex);

    //        if (selectedCard >= cards.Count)
    //        {
    //            selectedCard = cards.Count - 1; // Ensure selectedCard is within bounds
    //            if (selectedCard < 0) selectedCard = 0; // If no cards are left, reset to 0
    //        }

    //        RenderUITiles();
    //    }
    //}
}

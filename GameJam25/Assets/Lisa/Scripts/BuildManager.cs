using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BuildManager : MonoBehaviour
{
    public Tilemap tilemap;
    public List<GameObject> cards;
    public List<GameObject> UICards;


    public int selectedCard = 0; // this should be based on the cards in the inventory later.

    public Transform cardGridUI;
    public GameObject tilePreview;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddMultipleCards();
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

        // if the cards list doesn't have the same count as the ui element list, update the ui (draw the whole thing again)
        if(cards.Count != UICards.Count)
        {
            int lastIndex = UICards.Count - 1;
            AddSingleCard(cards[lastIndex]);
        }

        // TODO: If a new card was added, update the ui;
    }

    private void AddMultipleCards()
    {
        int i = 0;

        foreach (GameObject card in cards)
        {
            GameObject UICard = Instantiate(card);
            UICard.GetComponent<BuildingCard>().cardIndex = i;
            UICard.transform.SetParent(cardGridUI);
            UICard.transform.localScale = new Vector3(1f, 1f, 1f);

            UICards.Add(UICard);

            i++;
        }
    }

    public void AddSingleCard(GameObject card)
    {
        GameObject UICard = Instantiate(card);
        UICard.GetComponent<BuildingCard>().cardIndex = cards.Count - 1;
        UICard.transform.SetParent(cardGridUI);
        UICard.transform.localScale = new Vector3(1f, 1f, 1f);

        UICards.Add(UICard);
    }
    public void RenderUITiles()
    {
        int i = 0;
        foreach (GameObject card in UICards)
        {
            card.transform.localScale = new Vector3(1f, 1f, 1f);
            card.GetComponent<BuildingCard>().cardIndex = i;
            i++;
        }
    }
    public void PreviewCard(Vector3 position)
    {
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
        if(tilePreview == null)
        {
            PreviewCard(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }       
    }

    public void RemoveCardFromList(int cardIndex)
    {
        // Remove the card from both the cards list and the UI list
        if (cardIndex >= 0 && cardIndex < cards.Count)
        {
            cards.RemoveAt(cardIndex);

            Destroy(UICards[cardIndex]);
            UICards.RemoveAt(cardIndex);

            Debug.Log(cardIndex);

            if (selectedCard >= cards.Count)
            {
                selectedCard = cards.Count - 1; // Ensure selectedCard is within bounds
                if (selectedCard < 0) selectedCard = 0; // If no cards are left, reset to 0
            }


            RenderUITiles();
        }
    }
}

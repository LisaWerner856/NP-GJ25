using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;
using Unity.VisualScripting;

public class BuildManager : MonoBehaviour
{
    public Tilemap tilemap;
    public List<GameObject> cards;
    public List<GameObject> UICards;

    public int selectedCard = 0; // this should be based on the cards in the inventory later.

    public Transform cardGridUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int i = 0;
        foreach (GameObject card in cards)
        {
            GameObject UICard = Instantiate(card);
            UICard.transform.SetParent(cardGridUI);
            UICard.transform.localScale = new Vector3(1f, 1f, 1f);

            // Set the selected card scale to be 1,5 times the size
            if (i == selectedCard)
            {
                UICard.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            }

            UICards.Add(UICard);

            i++;

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedCard = 0;
            RenterUITiles();

        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedCard = 1;
            RenterUITiles();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), cards[selectedCard].GetComponent<BuildingCard>().buildingTile);
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), null);
        }
    }

    public void RenterUITiles()
    {
        int i = 0;
        foreach (GameObject tile in UICards)
        {
            tile.transform.localScale = new Vector3(1f, 1f, 1f);

            // Set the selected card scale to be 1,5 times the size
            if (i == selectedCard)
            {
                tile.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            }

            i++;
        }
    }
}

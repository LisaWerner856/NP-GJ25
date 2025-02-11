using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class BuildManager : MonoBehaviour
{
    public BuildingCard buildingCard; // Building card reference

    public Tilemap tilemap;
    public Tile[] tiles;
    public List<GameObject> UITiles;

    public int selectedTile = 0; // this should be based on the cards in the inventory later.

    public Transform tileGridUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int i = 0;
        foreach (Tile tile in tiles)
        {
            GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f, 1f, 1f);

            //GameObject card = buildingCard.gameObject;
            //card.transform.parent = tileGridUI;
            //card.transform.localScale = new Vector3(1f, 1f, 1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;


            Color tileColor = UIImage.color;
            tileColor.a = 0.5f; // Set the alpha of the sprite to 70%, this makes it slightly transparent.

            if (i == selectedTile)
            {
                tileColor.a = 1f; // If it's selected, it's full opacity.
            }

            UIImage.color = tileColor;
            UITiles.Add(UITile);

            i++;

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTile = 0;
            RenterUITiles();

        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTile = 1;
            RenterUITiles();
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTile = 2;
            RenterUITiles();
        } else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedTile = 3;
            RenterUITiles();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), tiles[selectedTile]);
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
        foreach (GameObject tile in UITiles)
        {
            Image UIImage = tile.GetComponent<Image>();
            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile)
            {
                tileColor.a = 1f; // If it's selected, it's full opacity.
            }

            UIImage.color = tileColor;
            i++;
        }
    }
}

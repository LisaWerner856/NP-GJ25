using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

[System.Serializable]
public class BuildingCard : MonoBehaviour
{
    public TMP_Text buildingName;

    public Image image;

    public BuildingCardSO buildingCardSO; // Building Card scriptable object

    public int tileWidth;
    public int tileHeight;

    public Tile buildingTile;

    private void Start()
    {
        image.sprite = buildingCardSO.buildingImage;
        buildingName.text = buildingCardSO.buildingName;
    }
}


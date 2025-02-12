using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

[System.Serializable]
public class BuildingCard : MonoBehaviour
{
    // Reference to the build manager
    public BuildManager bm;

    public TMP_Text buildingName;

    public Image image;

    public BuildingCardSO buildingCardSO; // Building Card scriptable object

    public int tileWidth;
    public int tileHeight;

    public Tile buildingTile;

    private void Awake()
    {
        bm = GameObject.Find("BuildManager").GetComponent<BuildManager>();
    }
    private void Start()
    {
        image.sprite = buildingCardSO.buildingImage;
        buildingName.text = buildingCardSO.buildingName;
    }

    public void OnCardClick()
    {
        Debug.Log($"Button clicked! and {bm.tilePreview} ");

        //if (bm.tilePreview != null)
        //{
            bm.PlaceCard();
        //}
    }
}


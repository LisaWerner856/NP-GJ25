using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

[System.Serializable]
public class BuildingCard : MonoBehaviour
{
    // Reference to the build manager
    private BuildManager bm;

    // Card UI Things 
    public TMP_Text buildingName;
    public Image image;

    // Reference to the scriptable object, to get the data from
    public BuildingCardSO buildingCardSO;

    public int tileWidth;
    public int tileHeight;

    // Reference to the actual tile being built. Has to be set manually because I'm very good at programming, yes
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

    private void OnMouseEnter()
    {
        //transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    public void OnCardClick()
    {
        bm.PlaceCard();
    }
}


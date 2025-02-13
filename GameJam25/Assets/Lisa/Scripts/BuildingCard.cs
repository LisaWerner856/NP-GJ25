using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

[System.Serializable]
public class BuildingCard : MonoBehaviour
{
    // Reference to the build manager
    private BuildManager bm;

    // Card Index, used to reference the selected card
    public int cardIndex;

    // Card UI Things 
    public TMP_Text buildingName;
    public UnityEngine.UI.Image image;

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
    public void OnCardClick()
    {
        bm.PlaceCard(cardIndex);
    }

    public void CardEffectForest(int value = 10)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
        ////Forest Building Card: hogere base HP
        player.GetComponent<Unit>().maxHp += value;
        Debug.Log("Forest effect called!");
    }

    public void CardEffectMountain(int value = 10)
    {
        //Mountain Building Card: Player damage increase
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Unit>().damage += value;

        Debug.Log($"Mountain effect called! {value} added!");
    }
    public void CardEffectWater()
    {
        //Water Building Card: Geeft de player een beter heal tijdens battel
        Debug.Log("Water effect called!");

    }
}


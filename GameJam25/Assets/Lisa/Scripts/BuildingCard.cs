using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

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

    public void CardEffectForest(GameObject playerRef)
    {
        // Forest Building Card: hogere base HP
        Debug.Log("Forest effect called!");
        Debug.Log($"Player HP before effect: {playerRef.GetComponent<Unit>().maxHp}");
        playerRef.GetComponent<Unit>().maxHp += buildingCardSO.effectValue;
        Debug.Log($"Player HP after effect: {playerRef.GetComponent<Unit>().maxHp}");
    }

    public void CardEffectMountain(GameObject playerRef)
    {
        // Mountain Building Card: Player damage increase
        Debug.Log($"Player HP before effect: {playerRef.GetComponent<Unit>().damage}");
        playerRef.GetComponent<Unit>().damage += buildingCardSO.effectValue;
        Debug.Log($"Player HP after effect: {playerRef.GetComponent<Unit>().damage}");
    }
    public void CardEffectWater(GameObject playerRef)
    {
        // Water Building Card: Geeft de player een beter heal tijdens battle
        Debug.Log("Water effect called!");
        Debug.Log($"Player HP before effect: {playerRef.GetComponent<Unit>().healBuff}");
        playerRef.GetComponent<Unit>().healBuff = buildingCardSO.effectValue;
        Debug.Log($"Player HP after effect: {playerRef.GetComponent<Unit>().healBuff}");

    }
}


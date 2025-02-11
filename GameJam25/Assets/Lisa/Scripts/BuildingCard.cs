using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class BuildingCard : MonoBehaviour
{
    public TMP_Text buildingName;
    public Image image;
    //public GameObject buildingPrefab;
    public BuildingCardSO buildingCardSO; // Building Card scriptable object
    public int tileWidth;
    public int tileHeight;

    private void Start()
    {
        image.color = Color.red;
        buildingName.text = buildingCardSO.buildingName;
    }
}


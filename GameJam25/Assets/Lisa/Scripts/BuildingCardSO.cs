using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New BuildingCard", menuName = "BuildingCard")]
public class BuildingCardSO : ScriptableObject
{
    public string buildingName;
    public Sprite buildingImage;

    Tile buildingTile;
    public int width;
    public int height;
}

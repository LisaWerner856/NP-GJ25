using UnityEngine;

[CreateAssetMenu(fileName = "New BuildingCard", menuName = "BuildingCard")]
public class BuildingCardSO : ScriptableObject
{
    public string buildingName;
    public Sprite buildingImage;

    public int effectValue;

}

using UnityEngine;

[CreateAssetMenu(fileName = "New BuildingCard", menuName = "BuildingCard")]
public class BuildingCardSO : ScriptableObject
{
    public string buildingName;
    public GameObject buildingPrefab;
    public int width;
    public int height;
}

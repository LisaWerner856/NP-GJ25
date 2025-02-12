using System;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public Canvas parentCanvas;
    public GameObject card;
    public void DropTheLoot()
    {
        Debug.Log("Dropping loot!");
        Instantiate(card, parentCanvas.transform.position, Quaternion.identity); // Instantiate new card on 0,0,0 with no rotation.
    }
}

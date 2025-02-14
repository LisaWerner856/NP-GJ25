using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public Canvas canvas;
    public List<GameObject> enemies = new List<GameObject>(); 
    public List<Transform> possibleSpawnLocations = new List<Transform>();
    [SerializeField] private int spawnBuffer = 2; // Add this spawn buffer, so enemies don't spawn too close to the base.

    private void Start()
    {
        StartNewRound();
    }

    public void StartNewRound()
    {
        Debug.Log("New Round Started!");
        // Spawn enemies, increase their level
        int rndEnemy = Random.Range(0, enemies.Count - 1);
        int rndSpawnPos = Random.Range(0 + spawnBuffer, possibleSpawnLocations.Count - 1);

        //Instantiate(enemies[rndEnemy], possibleSpawnLocations[rndEnemy].position, Quaternion.identity);
        GameObject newEnemy = Instantiate(enemies[rndEnemy], canvas.transform);
        newEnemy.transform.position = new Vector3(possibleSpawnLocations[rndSpawnPos].position.x, possibleSpawnLocations[rndSpawnPos].position.y, 0);
    }
}

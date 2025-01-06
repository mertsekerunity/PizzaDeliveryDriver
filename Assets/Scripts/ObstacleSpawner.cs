using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnRate = 1.0f;
    [SerializeField] float spawnInterval = 1.0f;
    [SerializeField] float xPos;
    [SerializeField] float yPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), spawnRate, spawnInterval);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-xPos, xPos);
        float randomY = Random.Range(-yPos, yPos);
        Vector2 randomPos = new Vector2(randomX, randomY);
        Instantiate(obstaclePrefab, randomPos, Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnRate = 1.0f;
    [SerializeField] float spawnInterval = 1.0f;
    [SerializeField] float xPosLim;
    [SerializeField] float xNegLim;
    [SerializeField] float yPosLim;
    [SerializeField] float yNegLim;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), spawnRate, spawnInterval);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(xNegLim, xPosLim);
        float randomY = Random.Range(yNegLim, yPosLim);
        Vector2 randomPos = new Vector2(randomX, randomY);
        Instantiate(obstaclePrefab, randomPos, Quaternion.identity);
    }
}
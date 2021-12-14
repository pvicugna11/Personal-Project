using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;

    private float xRange = 20;
    private float zRange = 20;
    private float yPos = 0.6f;

    private float startTime = 1.0f;
    private float enemyInterval = 5.0f;
    private float powerupInterval = 10.0f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, enemyInterval);
        InvokeRepeating("SpawnPowerup", startTime, powerupInterval);
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[index], SpawnPos(), enemyPrefabs[index].transform.rotation);
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, SpawnPos(), powerupPrefab.transform.rotation);
    }

    private Vector3 SpawnPos()
    {
        float xPos = Random.Range(-xRange, xRange);
        float zPos = Random.Range(-zRange, zRange);

        Vector3 enemyPos = new Vector3(xPos, yPos, zPos);

        return enemyPos;
    }
}

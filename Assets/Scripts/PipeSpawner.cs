using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : ObjectPool
{
    [SerializeField] private GameObject template;
    [SerializeField] private float secondBetweenSpawn; 
    [SerializeField] private float maxSpawnPositionY;
    [SerializeField] private float minSpawnPositionY;

    private float elapsedTime = 0;
    private float standartSecondBetweenSpawn;

    private void Start()
    {   
        standartSecondBetweenSpawn = secondBetweenSpawn;
        Initialize(template);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                elapsedTime = 0;

                float SpawnPositionY = Random.Range(minSpawnPositionY, maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, SpawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }
    }

    public void HardGame()
    {
        if (secondBetweenSpawn > 0.5f)
        {
            secondBetweenSpawn -= 0.2f;
        }
    }

    public void ResetSpawner()
    {
        secondBetweenSpawn = standartSecondBetweenSpawn;
    }
}

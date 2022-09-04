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

    private void Start()
    {
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
}

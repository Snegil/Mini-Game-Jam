using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    float spawnTimer;
    float setSpawnTimer;

    [SerializeField]
    int maxEnemies = 40;

    [SerializeField]
    GameObject player;

    List<Transform> spawnPoints = new();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints.Add(transform.GetChild(i));
        }

        setSpawnTimer = spawnTimer;
    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && spawnPoints[0].childCount < maxEnemies)
        {
            GameObject instantiated = Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity, spawnPoints[0]);
            instantiated.GetComponent<EnemyAI>().AssignPlayerVariable(player);
            spawnTimer = setSpawnTimer;
        }
    }
}

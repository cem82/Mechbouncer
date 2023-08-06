using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform[] spawnPositions;
    public bool moveUp = false;
    public Transform arrivalIndicator;

    public float spawnRate = 2f;

    private Coroutine rocketSpawnCoroutine;

    private void Start()
    {
        rocketSpawnCoroutine = StartCoroutine(SpawnRockets());
    }

    private IEnumerator SpawnRockets()
    {
        while (true)
        {
            Transform randomSpawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];


            GameObject enemy = Instantiate(rocketPrefab, randomSpawnPosition.position, Quaternion.identity);
            Rocket enemyMovement = enemy.GetComponent<Rocket>();

            // Set the movement direction based on the spawner
            if (moveUp)
            {
                enemyMovement.moveUp = true;
            }
            else
            {
                enemyMovement.moveUp = false;
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }
}

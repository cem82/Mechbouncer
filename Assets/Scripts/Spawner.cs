using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public int maxEnemies = 10;

    private int currentEnemyCount = 0;

    [SerializeField] bool moveRightSpawner;
    public GameObject indicatorPrefab;
    private void Start()
    {
        
        StartCoroutine(SpawnEnemies());

    }

    private IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemies)
        {

            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            for (int i = 0; i < spawnPoint.transform.childCount; i++)
            {
                Transform child = spawnPoint.transform.GetChild(i);
                child.gameObject.SetActive(true);
                float scaleValue = moveRightSpawner ? -0.3f : 0.3f;
                child.localScale = new Vector3(scaleValue, child.localScale.y, child.localScale.z);
            }
            yield return new WaitForSeconds(0.2f);



            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            Enemy enemyMovement = enemy.GetComponent<Enemy>();


            enemyMovement.moveRight = moveRightSpawner;


            Vector3 enemyScale = enemy.transform.localScale;
            enemyScale.x = moveRightSpawner ? -0.5f : 0.5f;
            enemy.transform.localScale = enemyScale;


            enemyMovement.moveRight = moveRightSpawner;

            currentEnemyCount++;

            yield return new WaitForSeconds(0.3f);
            for (int i = 0; i < spawnPoint.transform.childCount; i++)
            {
                Transform child = spawnPoint.transform.GetChild(i);
                child.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(spawnRate - 0.5f);


        }
    }
}

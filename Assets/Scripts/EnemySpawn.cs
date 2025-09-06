using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    private float spawnTimer;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void SpawnEnemy()
    {
        
        var randomIndex = Random.Range(0, spawnPoints.Length);
        var randomIndex2 = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[randomIndex2], spawnPoints[randomIndex].position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }
}

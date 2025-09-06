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

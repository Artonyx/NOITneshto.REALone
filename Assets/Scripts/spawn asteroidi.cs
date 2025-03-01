using System.Collections;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 1.0f;
    public float spawnRangeX = 10f;
    public float spawnHeight = 6f;
    public int maxAsteroids = 15;
    public float minSpeed = 2f, maxSpeed = 5f;

    public int asteroidCount = 0;

    void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)  
        {
            if (asteroidCount < maxAsteroids)
            {
                SpawnAsteroid(); 
                asteroidCount++;  
            }

            yield return new WaitForSeconds(spawnRate);
            
        }
    }

    private void SpawnAsteroid()
    {
        
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnHeight);

        
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, -Random.Range(minSpeed, maxSpeed));
        }
    }

    
    public void DecreaseCount()
    {
        if (asteroidCount > 0)
        {
            asteroidCount--;
        }
    }
    
    
}
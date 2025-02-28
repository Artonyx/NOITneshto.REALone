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
        while (true)  // Keep spawning indefinitely
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
        // Random spawn position within defined range
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnHeight);

        // Instantiate asteroid
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Apply random speed to the asteroid
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, -Random.Range(minSpeed, maxSpeed));  // Set the velocity of the asteroid
        }
    }

    // Decrease the asteroid count when an asteroid is destroyed
    public void DecreaseCount()
    {
        if (asteroidCount > 0)
        {
            asteroidCount--;
        }
    }
    
}
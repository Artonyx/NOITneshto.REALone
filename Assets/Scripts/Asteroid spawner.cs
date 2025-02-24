using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 1.0f; 
    public float spawnRangeX = 10f; 
    public float spawnHeight = 6f; 
    public int maxAsteroids = 10;
    public float minSpeed = 2f, maxSpeed = 5f;

    private int _asteroidCount = 0;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (_asteroidCount < maxAsteroids)
        {
            
            SpawnAsteroid(); 
            _asteroidCount++;
            
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnAsteroid()
    {
        
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnHeight);

        
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, -Random.Range(minSpeed, maxSpeed));
        }

        // Destroy after some time to avoid clutter
        Destroy(asteroid, 10f);
        _asteroidCount--;
    }
}
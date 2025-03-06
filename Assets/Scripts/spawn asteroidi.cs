using System.Collections;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public float spawnRate = 1.0f;
    public float spawnRangeY = 5f; 
    public float minSpeed = 2f, maxSpeed = 5f;

    public GameObject[] asteroids;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)  
        { 
            SpawnAsteroid(); 
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnAsteroid()
    {
        float screenRightX = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
        
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        
        Vector2 spawnPosition = new Vector2(screenRightX, randomY);
        
        int randomIndex = Random.Range(0, asteroids.Length);
        GameObject asteroid = Instantiate(asteroids[randomIndex], spawnPosition, Quaternion.identity);


        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-Random.Range(minSpeed, maxSpeed), 0);
        }
    }
}
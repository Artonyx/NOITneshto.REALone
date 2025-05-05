using System.Collections; using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public float spawnRate = 32f;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float destroyDelay = 10f;
    public GameObject[] asteroids;
    void Start()
    {
        if (Camera.main == null)
        {
            Debug.LogError("No Main Camera found in the scene!");
            return;
        }
        if (asteroids == null || asteroids.Length == 0)
        {
            Debug.LogError("Asteroids array is empty or not assigned!");
            return;
        }
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

    void SpawnAsteroid()
    {
        Camera cam = Camera.main;
        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        float spawnX = topRight.x;
        float groundOffset = bottomLeft.y + 6f;
        float spawnY = Random.Range(groundOffset, topRight.y);
        Vector2 spawnPosition = new(spawnX, spawnY);
        int randomIndex = Random.Range(0, asteroids.Length);

        if (asteroids[randomIndex] == null)
        {
            Debug.LogWarning($"Asteroid at index {randomIndex} is null! Skipping spawn.");
            return;
        }

        GameObject asteroid = Instantiate(asteroids[randomIndex], spawnPosition, Quaternion.identity);
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-Random.Range(minSpeed, maxSpeed), 0);
        }
        StartCoroutine(DestroyAfterDelay(asteroid, destroyDelay));
    }

    IEnumerator DestroyAfterDelay(GameObject asteroid, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (asteroid != null)
        {
            Destroy(asteroid);
        }
    }
}
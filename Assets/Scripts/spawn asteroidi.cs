using System.Collections; using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public float spawnRate = 0.5f;
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
        if (cam == null)
        {
            Debug.LogError("Camera.main is null during SpawnAsteroid!");
            return;
        }

        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        float spawnX = topRight.x;
        float groundOffset = bottomLeft.y + 1.5f;
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
        else
        {
            Debug.LogWarning($"Asteroid {asteroids[randomIndex].name} at index {randomIndex} has no Rigidbody2D!");
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
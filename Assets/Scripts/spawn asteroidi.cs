using System.Collections; using UnityEngine;

public class AsteroidSpawn : MonoBehaviour { public float spawnRate = 0.5f;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float destroyDelay = 10f;
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

void SpawnAsteroid()
{
    Camera cam = Camera.main;
    if (cam == null)
    {
        Debug.LogError("Camera.main is null during SpawnAsteroid!");
        return;
    }

    // Convert screen corners to world coordinates
    Vector2 bottomLeft = cam.ScreenToWorldPoint(Vector2.zero);
    Vector2 topRight = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    float spawnX = topRight.x + 3f;
    float minSpawnY = bottomLeft.y + 7f;
    float spawnY = Random.Range(minSpawnY, topRight.y);
    Vector2 spawnPosition = new Vector2(spawnX, spawnY);
    int randomIndex = Random.Range(0, asteroids?.Length ?? 0);

    //check for problems in spawning
    if (asteroids[randomIndex] == null)
    {
        Debug.LogWarning($"Asteroid at index {randomIndex} is null! Skipping spawn.");
        return;
    }

    GameObject asteroid = Instantiate(asteroids[randomIndex], spawnPosition, Quaternion.identity);
    Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
    //check for RigidBody
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
    //destroy after delay
    yield return new WaitForSeconds(delay);

    if (asteroid != null)
    {
        Destroy(asteroid);
    }
}

}
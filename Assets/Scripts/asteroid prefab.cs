using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int health = 4;
    public GameObject explosionEffect;
    private AsteroidSpawn _asteroidSpawn;

    void Start()
    {
        _asteroidSpawn = FindFirstObjectByType<AsteroidSpawn>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health--;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                DestroyAsteroid();
            }
        }
        else if (other.CompareTag("Rocket"))
        {
            health = 0;
            Destroy(other.gameObject);
            DestroyAsteroid();
        }
    }

    void DestroyAsteroid()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
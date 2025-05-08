using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public int healthOfAsteroid = 4;
    public GameObject explosionEffect;
    private AsteroidSpawn _asteroidSpawn;

    void Start()
    {
        _asteroidSpawn = FindObjectOfType<AsteroidSpawn>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            healthOfAsteroid--;
            Destroy(other.gameObject);
            Debug.Log("Projectile hit asteroid");

            if (healthOfAsteroid <= 0)
                DestroyAsteroid();
        }
        else if (other.CompareTag("Rocket"))
        {
            healthOfAsteroid = 0;
            Destroy(other.gameObject);
            DestroyAsteroid();
        }
    }

    void DestroyAsteroid()
    {
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
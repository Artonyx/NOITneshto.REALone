using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int healthOfAsteroid = 4;
    public GameObject explosionEffect;
    
    public float minRotationSpeed = -100f;  // Minimum spin speed
    public float maxRotationSpeed =  100f;  // Maximum spin speed 
    private float rotationSpeed;            // Actual randomized spin speed

    private AsteroidSpawn _asteroidSpawn;

    void Start()
    {
        _asteroidSpawn = FindObjectOfType<AsteroidSpawn>();
        // Randomize spin speed per asteroid so each spins independently
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        // Spin around Z-axis like a fidget spinner
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
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
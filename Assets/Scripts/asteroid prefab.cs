using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int health = 2; 
    public GameObject explosionEffect; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile")) 
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
            health -= health;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                DestroyAsteroid();
            }
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
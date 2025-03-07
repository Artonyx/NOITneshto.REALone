using UnityEngine;

public class Hitbox2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.collider.name);

        // Check if the object we collided with is the player
        PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
            Destroy(gameObject); // Destroy asteroid on impact
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.name);

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
            Destroy(gameObject); // Destroy asteroid when hit by a bullet
        }
    }
}
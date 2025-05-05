using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Hitbox2D : MonoBehaviour { private void OnCollisionEnter2D(Collision2D collision) { Debug.Log($"Collision detected between {gameObject.name} and {collision.collider.name}");

        PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger detected between {gameObject.name} and {other.name}");

        if (other.CompareTag("Projectile") || other.CompareTag("Rocket"))
        {
            Destroy(gameObject);
        }
    }

}
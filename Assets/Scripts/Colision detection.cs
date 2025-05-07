using UnityEngine;

public class CollisionDetection : MonoBehaviour { private void OnCollisionEnter2D(Collision2D collision) { Debug.Log($"Collision detected between {gameObject.name} and {collision.collider.name}");

        PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
            Destroy(gameObject);
        }
    }

}
using UnityEngine;

public class Hitbox2D : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.collider.name);

        Health health = collision.collider.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.name);

        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}
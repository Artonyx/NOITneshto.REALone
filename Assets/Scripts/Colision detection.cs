using UnityEngine;

public class Hitbox2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit detected with: " + other.name);
        
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}


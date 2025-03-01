using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("🚀 Ship crashed into an asteroid! Game Over!");
            Destroy(gameObject);
        }
    }
}
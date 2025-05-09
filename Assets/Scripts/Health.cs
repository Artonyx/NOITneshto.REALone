using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject lossScreen;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player took damage! Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        Destroy(gameObject);
        lossScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int healthOfAsteroid = 3;
    public GameObject explosionEffect;
    private audioManager audioManager;
    private bool isDestroyed = false;

    private void Awake()
    {
        GameObject audioManagerObject = GameObject.Find("AudioManager");
        if (audioManagerObject != null)
            audioManager = audioManagerObject.GetComponent<audioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed) return;

        if (other.CompareTag("Projectile"))
        {
            healthOfAsteroid--;
            Destroy(other.gameObject);
            Debug.Log("Projectile hit asteroid");

            if (audioManager != null)
                audioManager.PlaySFX(audioManager.onHit);

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

    private void DestroyAsteroid()
    {
        if (isDestroyed) return;
        isDestroyed = true;

        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        if (audioManager != null)
            audioManager.PlaySFX(audioManager.asteroidDeath);

        Destroy(gameObject);
    }
}
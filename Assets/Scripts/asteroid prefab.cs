using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int healthOfAsteroid = 3;
    public GameObject explosionEffect;

    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip impactSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            healthOfAsteroid--;
            Destroy(other.gameObject);
            Debug.Log("Projectile hit asteroid");

            
            if (impactSound != null && audioSource != null)
                audioSource.PlayOneShot(impactSound);

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
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        if (explosionSound != null && audioSource != null)
            audioSource.PlayOneShot(explosionSound);

        Destroy(gameObject);
    }
}
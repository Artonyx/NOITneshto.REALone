using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the normal projectile prefab in the Inspector
    public GameObject rocketPrefab; // Assign the rocket prefab in the Inspector
    public Transform firePoint; // Assign an empty GameObject at the shooting position
    public float projectileSpeed = 10f;
    public float rocketSpeed = 7f;
    public float fireRate = 0.5f;
    public float rocketFireRate = 1.5f;

    private float _nextFireTime;
    private float _nextRocketFireTime;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= _nextFireTime)
        {
            ShootProjectile();
            _nextFireTime = Time.time + fireRate;
        }
        
        if (Input.GetKey(KeyCode.Mouse1) && Time.time >= _nextRocketFireTime)
        {
            ShootRocket();
            _nextRocketFireTime = Time.time + rocketFireRate;
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * projectileSpeed;
        }
    }

    void ShootRocket()
    {
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * rocketSpeed;
        }
    }
}
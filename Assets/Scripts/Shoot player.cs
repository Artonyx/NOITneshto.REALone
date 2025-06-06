using UnityEngine;

public class SpaceshipShooting : MonoBehaviour { 
    public GameObject projectilePrefab;
    public GameObject rocketPrefab;
    public Transform firePoint; 
    public float projectileSpeed = 10f; 
    public float rocketSpeed = 7f;
    public float fireRate = 0.1f;
    public float rocketFireRate = 1.5f; 

    private float _nextFireTime;
    private float _nextRocketFireTime;

    public static float DeadZone = 20;

    void Start()
    {
        //check for fire point
        if (firePoint == null)
        {
            firePoint = transform.Find("FirePoint");
            if (firePoint == null)
            {
                Debug.LogError("FirePoint is not assigned and was not found as a child of the spaceship!");
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= _nextFireTime)
        {
            ShootProjectile();
            _nextFireTime = Time.time + fireRate;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time >= _nextRocketFireTime)
        {
            ShootRocket();
            _nextRocketFireTime = Time.time + rocketFireRate;
        }
    }

    void ShootProjectile()
    {
        if (firePoint == null) return;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.tag = "Projectile";
        projectile.SetActive(true);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * projectileSpeed;
        }
    }

    void ShootRocket()
    {
        if (firePoint == null) return;
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        rocket.tag = "Rocket";
        rocket.SetActive(true);
        Rigidbody2D rb = rocket.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * rocketSpeed;
        }
    }

}
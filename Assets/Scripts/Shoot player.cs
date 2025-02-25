using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject rocketPrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float rocketSpeed = 7f;
    public float fireRate = 0.1f;
    public float rocketFireRate = 1.5f;
    public float laserDamage = 10;
    public float rocketDamage = 30;

    private float _nextFireTime;
    private float _nextRocketFireTime;
    
    public static float DeadZone = 10;

    void Start()
    {
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
        if (firePoint == null) return;
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
        RocketScript rocketScript = rocket.GetComponent<RocketScript>();
        if (rocketScript != null)
        {
            rocketScript.SetTarget(FindClosestAsteroid());
        }
    }

    Transform FindClosestAsteroid()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        Transform closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        
        foreach (GameObject asteroid in asteroids)
        {
            float distance = (asteroid.transform.position - currentPosition).sqrMagnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = asteroid.transform;
            }
        }
        return closest;
    }
}

[RequireComponent(typeof(Rigidbody2D))]
public class RaketaScript : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D _rb;
    public float speed = 5f;
    public float rotateSpeed = 100f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector2 direction = (Vector2)(target.position - transform.position);
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        _rb.angularVelocity = -rotateAmount * rotateSpeed;
        _rb.linearVelocity = transform.up * speed;
        
        if (transform.position.x > SpaceshipShooting.DeadZone)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}

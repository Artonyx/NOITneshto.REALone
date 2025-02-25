using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class RocketScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D _rb;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Asteroid").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = transform.forward * 10;
        if(transform.position.x>SpaceshipShooting.DeadZone)
        {
            Debug.Log("Rocket deleted");
            Destroy(gameObject);
        }
    }
}

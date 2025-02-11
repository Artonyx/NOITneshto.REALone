using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustPower = 10f;
    public float rotationSpeed = 100f;
    public float dragFactor = 0.99f; // Simulates friction in space

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
    }

    void FixedUpdate()
    {
        ApplyDrag();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * thrustPower);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * thrustPower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * thrustPower);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * thrustPower);
        }
    }

    void ApplyDrag()
    {
        rb.linearVelocity *= dragFactor;
    }
}

using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustPower = 70f;
    public float rotationSpeed = 100f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * thrustPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * thrustPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * thrustPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * thrustPower * Time.deltaTime);
        }
    }


}

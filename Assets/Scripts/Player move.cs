using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustPower = 70f;
    public float rotationSpeed = 100f;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(Vector2.up * thrustPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(Vector2.down * thrustPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector2.right * thrustPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector2.left * thrustPower * Time.deltaTime);
        }
    }



}

using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustPower = 100f;
    public float rotationSpeed = 120f;

    private Rigidbody2D _rb;
    private float _screenWidth;
    private float _screenHeight;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rb.freezeRotation = true;

        
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _screenWidth = screenBounds.x;
        _screenHeight = screenBounds.y;
    }

    void Update()
    {
        HandleMovement();
        KeepWithinBounds();
    }

    void HandleMovement()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector2.up;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector2.down;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector2.right;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector2.left;

        
    }

    void KeepWithinBounds()
    {
        Vector2 position = transform.position;
        Vector2 velocity = _rb.linearVelocity;
        
        if (position.x > _screenWidth)
        {
            transform.position = new Vector2(_screenWidth, position.y);
            _rb.linearVelocity = new Vector2(-velocity.x, velocity.y); 
        }
        else if (position.x < -_screenWidth)
        {
            transform.position = new Vector2(-_screenWidth, position.y);
            _rb.linearVelocity = new Vector2(-velocity.x, velocity.y);
        }
        
        if (position.y > _screenHeight)
        {
            transform.position = new Vector2(position.x, _screenHeight);
            _rb.linearVelocity = new Vector2(velocity.x, -velocity.y); 
        }
        else if (position.y < -_screenHeight)
        {
            transform.position = new Vector2(position.x, -_screenHeight);
            _rb.linearVelocity = new Vector2(velocity.x, -velocity.y);
        }
    }
}

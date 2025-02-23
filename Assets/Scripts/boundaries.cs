using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private Rigidbody2D rb;
    public float bounceDamping = 0.5f; // Adjust this value to control bounce intensity

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        Vector2 velocity = rb.linearVelocity;

        // Bounce off Left and Right walls with damping
        if (viewPos.x <= screenBounds.x * -1 + objectWidth || viewPos.x >= screenBounds.x - objectWidth)
        {
            rb.linearVelocity = new Vector2(-velocity.x * bounceDamping, velocity.y); 
        }

        // Bounce off Top and Bottom walls with damping
        if (viewPos.y <= screenBounds.y * -1 + objectHeight || viewPos.y >= screenBounds.y - objectHeight)
        {
            rb.linearVelocity = new Vector2(velocity.x, -velocity.y * bounceDamping); 
        }

        // Keep the spaceship within the screen bounds
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
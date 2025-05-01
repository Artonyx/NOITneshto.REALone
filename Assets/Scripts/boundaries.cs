using UnityEngine;
public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private Rigidbody2D rb;
    public float bounceDamping = 0.5f;

    void Awake() // Ensure Rigidbody2D is initialized early
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is MISSING from the GameObject!");
        }
    }

    void LateUpdate()
    {
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is NULL in LateUpdate!");
            return;
        }

        Vector3 viewPos = transform.position;
        Vector2 velocity = rb.linearVelocity;

        // Bounce off Left and Right walls
        if (viewPos.x <= -screenBounds.x + objectWidth || viewPos.x >= screenBounds.x - objectWidth)
        {
            rb.linearVelocity = new Vector2(-velocity.x * bounceDamping, velocity.y);
        }

        // Bounce off Top and Bottom walls
        if (viewPos.y <= -screenBounds.y + objectHeight || viewPos.y >= screenBounds.y - objectHeight)
        {
            rb.linearVelocity = new Vector2(velocity.x, -velocity.y * bounceDamping);
        }

        // Keep within screen bounds
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}

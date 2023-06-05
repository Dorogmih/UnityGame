using UnityEngine;
using UnityEngine.Audio;

public class EnemyController : MonoBehaviour
{
    public float speed = 2.0f;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            spriteRenderer.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spriteRenderer.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
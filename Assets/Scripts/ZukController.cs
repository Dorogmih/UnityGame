using UnityEngine;
using UnityEngine.Audio;

public class ZukController : MonoBehaviour
{
    public float speed = 4f;
    private int direction = -1;

    void Start()
    {
        direction = -1;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
        else {
            direction *= -1;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
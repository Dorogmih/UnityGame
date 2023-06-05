using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;
    public float projectileLifetime = 4.0f;
    public Transform projectileSpawnPoint_Left;
    public Transform projectileSpawnPoint_Right;
    private SpriteRenderer spriteRenderer;

    private bool isFiring = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
                isFiring = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isFiring = false;
        }
    }

    private void FixedUpdate()
    {
        if (isFiring)
        {
            if (spriteRenderer.flipX == false)
            {
                GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint_Right.position, Quaternion.identity);
                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                projectileRb.velocity = Vector3.right * projectileSpeed;
                Destroy(projectile, projectileLifetime);
            }
            else if (spriteRenderer.flipX == true)
            {
                GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint_Left.position, Quaternion.identity);
                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                projectileRb.velocity = Vector3.left * projectileSpeed;
                Destroy(projectile, projectileLifetime);
            }

            isFiring = false;
        }
    }
}
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private HealthBar healthBar;
    private ScoreBar scoreBar;
    public Transform groundCheck;
    private bool isGrounded;
    private bool isNearWallLeft;
    private bool isNearWallRight;
    private bool shouldJump;
    public GameObject deathMessagePrefab;
    private GameObject healthBarObject;
    private GameObject scoreBarObject;
    public Transform deathMessageSpawnPoint;
    private int health = 3;
    private int score = 0;
    private Animator animator;
    public AudioClip coinSound;
    public AudioClip finishSound;
    public AudioClip damageSound;
    public AudioMixerGroup soundMixer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        healthBarObject = GameObject.Find("HealthBar");
        healthBar = healthBarObject.GetComponent<HealthBar>();
        scoreBarObject = GameObject.Find("ScoreBar");
        scoreBar = scoreBarObject.GetComponent<ScoreBar>();
        UpdateHealthBar(health);
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isWalking", true);
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        healthBarObject = GameObject.Find("HealthBar");
        healthBar = healthBarObject.GetComponent<HealthBar>();
        scoreBarObject = GameObject.Find("ScoreBar");
        scoreBar = scoreBarObject.GetComponent<ScoreBar>();
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health == 0)
        {
            Destroy(gameObject);
            GameObject deathmessage = Instantiate(deathMessagePrefab, deathMessageSpawnPoint.position, Quaternion.identity);
        }
        UpdateHealthBar(health);
    }
    public void UpdateHealthBar(int currentHealth)
    {
        switch (currentHealth)
        {
            case 0:
                healthBar.spriteRenderer.sprite = healthBar.health0;
                break;
            case 1:
                healthBar.spriteRenderer.sprite = healthBar.health1;
                break;
            case 2:
                healthBar.spriteRenderer.sprite = healthBar.health2;
                break;
            case 3:
                healthBar.spriteRenderer.sprite = healthBar.health3;
                break;
            default:
                healthBar.spriteRenderer.sprite = healthBar.health3;
                break;
        }
    }

    public void UpdateScore()
    {
        score += 1;
        switch (score)
        {
            case 0:
                scoreBar.spriteRenderer.sprite = scoreBar.num0;
                break;
            case 1:
                scoreBar.spriteRenderer.sprite = scoreBar.num1;
                break;
            case 2:
                scoreBar.spriteRenderer.sprite = scoreBar.num2;
                break;
            case 3:
                scoreBar.spriteRenderer.sprite = scoreBar.num3;
                break;
            case 4:
                scoreBar.spriteRenderer.sprite = scoreBar.num4;
                break;
            case 5:
                scoreBar.spriteRenderer.sprite = scoreBar.num5;
                break;
            default:
                scoreBar.spriteRenderer.sprite = scoreBar.num0;
                break;
        }
    }

    void Update()
    {
        isGrounded = rb.IsTouchingLayers();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = damageSound;
            audioSource.outputAudioMixerGroup = soundMixer;
            audioSource.Play();
            TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            UpdateScore();
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = coinSound;
            audioSource.outputAudioMixerGroup = soundMixer;
            audioSource.Play();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = finishSound;
            audioSource.outputAudioMixerGroup = soundMixer;
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
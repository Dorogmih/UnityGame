using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
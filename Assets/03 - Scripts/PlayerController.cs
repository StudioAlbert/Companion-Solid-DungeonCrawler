using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// Script fourre-tout : déplacement, attaque, vie et interface dans une seule classe.
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float fireballSpeed = 8f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private TMP_Text healthLabel;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private InputAction moveAction;
    private InputAction attackAction;
    private Vector2 facing = Vector2.right;
    private int health;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    void Start()
    {
        health = maxHealth;
        healthLabel.text = "PV : " + health;
    }

    void Update()
    {
        // Déplacement
        Vector2 input = moveAction.ReadValue<Vector2>();
        body.linearVelocity = input * speed;
        if (input != Vector2.zero)
        {
            facing = input.normalized;
            if (input.x != 0) spriteRenderer.flipX = input.x < 0;
        }

        // Attaque : boule de feu dans la direction du dernier déplacement
        if (attackAction.WasPressedThisFrame())
        {
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            fireball.GetComponent<Rigidbody2D>().linearVelocity = facing * fireballSpeed;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthLabel.text = "PV : " + Mathf.Max(health, 0);
        if (health <= 0) Destroy(gameObject);
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        healthLabel.text = "PV : " + health;
    }
}

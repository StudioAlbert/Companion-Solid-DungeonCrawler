using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// Script fourre-tout : déplacement, attaque, vie, interface, dégâts reçus et interactions.
public class PlayerController : MonoBehaviour, IEntity
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float fireballSpeed = 8f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private TMP_Text healthLabel;
    [SerializeField] private float interactRadius = 1f;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction interactAction;
    private Vector2 facing = Vector2.right;
    private int health;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        interactAction = InputSystem.actions.FindAction("Interact");
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

        // Interaction : on parle à tout ce qui est proche, et on utilise tout ce qui est proche
        if (interactAction.WasPressedThisFrame())
        {
            var reached = new HashSet<IEntity>();
            foreach (Collider2D hit in Physics2D.OverlapCircleAll(transform.position, interactRadius))
            {
                if (hit.TryGetComponent(out IEntity entity) && entity != (IEntity)this && reached.Add(entity))
                {
                    entity.Talk();
                    entity.Use(this);
                }
            }
        }
    }

    // Dégâts reçus : un if par danger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spider"))
        {
            TakeDamage(10);
        }
        else if (other.CompareTag("Arrow"))
        {
            TakeDamage(Random.Range(5, 11));
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("SpikeTrap"))
        {
            TakeDamage(25);
        }
        else if (other.CompareTag("Explosion"))
        {
            TakeDamage(30);
        }
        // nouveau danger ? on revient modifier ce fichier
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

    // Imposées par IEntity : le héros est piloté au clavier, n'attaque pas un héros,
    // ne parle pas et ne s'utilise pas
    public void Move(Vector3 target) { }
    public void Attack(PlayerController player) { }
    public void Talk() { }
    public void Use(PlayerController user) { }
}

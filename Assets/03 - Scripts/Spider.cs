using System.Collections;
using UnityEngine;

// L'araignée sait tout faire : se déplacer, attaquer, prendre des dégâts.
public class Spider : MonoBehaviour, IMovable, IAttacker, IDamageable
{
    [SerializeField] private int health = 30;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float detectionRadius = 4f;
    [SerializeField] private Collider2D bite;   // zone de morsure, avec ContactDamage

    private Rigidbody2D body;

    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        bite.enabled = false;
    }

    // Poursuit le héros quand il est assez proche
    public void Move(Vector3 target)
    {
        Vector2 toTarget = target - transform.position;
        float distance = toTarget.magnitude;
        bool chasing = distance < detectionRadius && distance > 0.7f;
        body.linearVelocity = chasing ? toTarget.normalized * speed : Vector2.zero;
    }

    public void Attack(PlayerHealth player)
    {
        StartCoroutine(Bite());
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }

    // La morsure active brièvement la zone de dégâts
    private IEnumerator Bite()
    {
        bite.enabled = true;
        yield return new WaitForSeconds(0.15f);
        bite.enabled = false;
    }
}

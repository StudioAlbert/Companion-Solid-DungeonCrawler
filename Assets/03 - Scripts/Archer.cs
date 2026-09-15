using UnityEngine;

// L'archer tire depuis son poste : il attaque et prend des dégâts, mais ne se déplace pas.
public class Archer : MonoBehaviour, IAttacker, IDamageable
{
    [SerializeField] private int health = 20;
    [SerializeField] private float attackRange = 8f;
    [SerializeField] private float attackCooldown = 2.5f;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float arrowSpeed = 6f;

    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;

    public void Attack(PlayerHealth player)
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Le sprite de la flèche pointe vers le haut
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0f, 0f, angle - 90f));
        arrow.GetComponent<Rigidbody2D>().linearVelocity = direction * arrowSpeed;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }
}

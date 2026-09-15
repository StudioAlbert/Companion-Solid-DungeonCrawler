using UnityEngine;

public class PlayerHealth : MonoBehaviour, IEntity
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthBar healthBar;

    private int health;

    void Start()
    {
        health = maxHealth;
        healthBar.Show(health);
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
        health = Mathf.Max(health - amount, 0);
        healthBar.Show(health);
        if (health == 0) Destroy(gameObject);
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        healthBar.Show(health);
    }

    // Imposées par IEntity : le héros ne se déplace pas sur ordre, n'attaque pas un héros,
    // ne parle pas et ne s'utilise pas
    public void Move(Vector3 target) { }
    public void Attack(PlayerHealth player) { }
    public void Talk() { }
    public void Use(PlayerHealth user) { }
}

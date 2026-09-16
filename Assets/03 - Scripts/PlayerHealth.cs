using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private HealthBar healthBar;

    private int health;

    void Start()
    {
        health = maxHealth;
        healthBar.Show(health);
    }

    // Dégâts reçus : un nouveau danger n'a pas besoin de modifier ce fichier
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out DamageSource source))
            TakeDamage(source.GetDamage());
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
}

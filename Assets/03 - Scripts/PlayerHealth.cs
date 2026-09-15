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

    // Imposées par IEntity : le héros ne se déplace pas sur ordre, n'attaque pas un héros,
    // ne parle pas et ne s'utilise pas
    public void Move(Vector3 target) { }
    public void Attack(PlayerHealth player) { }
    public void Talk() { }
    public void Use(PlayerHealth user) { }
}

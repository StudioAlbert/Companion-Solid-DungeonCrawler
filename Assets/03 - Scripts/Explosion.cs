using UnityEngine;

public class Explosion : DamageSource
{
    [SerializeField] private int damage = 30;
    [SerializeField] private float duration = 0.3f;

    public override int GetDamage() => damage;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Blesse tout ce qui peut prendre des dégâts : un baril voisin explose à son tour
        if (other.TryGetComponent(out IDamageable target)) target.TakeDamage(damage);
    }
}

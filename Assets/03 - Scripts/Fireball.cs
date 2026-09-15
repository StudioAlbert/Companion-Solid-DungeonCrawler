using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    [SerializeField] private float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Traverse le héros et les zones de déclenchement, s'arrête sur tout le reste
        if (other.CompareTag("Player") || other.isTrigger) return;
        if (other.TryGetComponent(out Enemy enemy)) enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}

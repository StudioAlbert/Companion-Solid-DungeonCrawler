using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int damage = 30;   // pour les ennemis ; le héros réagit au tag « Explosion »
    [SerializeField] private float duration = 0.3f;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Blesse les ennemis proches : un baril voisin explose à son tour
        if (other.TryGetComponent(out Enemy enemy)) enemy.TakeDamage(damage);
    }
}

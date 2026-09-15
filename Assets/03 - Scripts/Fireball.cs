using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Traverse le héros et les autres zones de déclenchement, s'arrête sur les murs
        if (other.CompareTag("Player") || other.isTrigger) return;
        Destroy(gameObject);
    }
}

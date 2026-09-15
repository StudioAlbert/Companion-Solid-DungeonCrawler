using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se plante dans les murs et le décor ; les dégâts au héros sont gérés par PlayerController
        if (other.isTrigger || other.CompareTag("Player") || other.GetComponent<Enemy>() != null) return;
        Destroy(gameObject);
    }
}

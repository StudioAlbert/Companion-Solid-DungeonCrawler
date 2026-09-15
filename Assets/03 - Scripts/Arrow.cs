using UnityEngine;

public class Arrow : DamageSource
{
    [SerializeField] private float lifetime = 3f;

    public override int GetDamage() => Random.Range(5, 11);

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se plante dans le héros, les murs et le décor ; traverse les ennemis et les barils
        if (other.isTrigger || other.GetComponent<IDamageable>() != null) return;
        Destroy(gameObject);
    }
}

using UnityEngine;

public class ExplodingBarrel : Enemy
{
    [SerializeField] private GameObject explosionPrefab;

    // Un baril ne bouge pas
    public override void Move(Vector3 target) { }

    // Un baril n'attaque pas
    public override void Attack(PlayerController player)
    {
        throw new System.NotSupportedException("Un baril n'attaque pas");
    }

    // Au premier coup, il explose
    public override void TakeDamage(int amount)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

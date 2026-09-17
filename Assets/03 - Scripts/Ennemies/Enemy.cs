using UnityEngine;

// Classe mère des ennemis : chaque sous-classe hérite de toutes ses promesses.
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 30;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown = 1.5f;

    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;

    public abstract void Move(Vector3 target);
    public abstract void Attack(PlayerController player);

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }

}

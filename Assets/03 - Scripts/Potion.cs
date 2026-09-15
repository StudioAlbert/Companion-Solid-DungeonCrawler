using UnityEngine;

public class Potion : MonoBehaviour, IEntity
{
    [SerializeField] private int healAmount = 30;

    public void Use(PlayerHealth user)
    {
        user.Heal(healAmount);
        Destroy(gameObject);
    }

    // Imposées par IEntity
    public void Move(Vector3 target) { }
    public void Attack(PlayerHealth player) { }
    public void TakeDamage(int amount) { }
    public void Talk() { }
}

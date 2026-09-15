using UnityEngine;

// Interface « tout-en-un » : chaque entité du donjon doit tout implémenter.
public interface IEntity
{
    void Move(Vector3 target);
    void Attack(PlayerController player);
    void TakeDamage(int amount);
    void Talk();
    void Use(PlayerController user);
}

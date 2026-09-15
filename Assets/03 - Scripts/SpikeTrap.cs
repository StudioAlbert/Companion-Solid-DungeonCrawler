using UnityEngine;

public class SpikeTrap : DamageSource
{
    [SerializeField] private int damage = 25;

    public override int GetDamage() => damage;
}

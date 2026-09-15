using UnityEngine;

// Dégâts au contact : posé sur la zone de morsure de l'araignée.
public class ContactDamage : DamageSource
{
    [SerializeField] private int damage = 10;

    public override int GetDamage() => damage;
}

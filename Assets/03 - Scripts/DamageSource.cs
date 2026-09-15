using UnityEngine;

// Tout ce qui blesse le héros : chaque danger déclare lui-même ses dégâts.
public abstract class DamageSource : MonoBehaviour
{
    public abstract int GetDamage();
}

using UnityEngine;

public class Potion : MonoBehaviour, IUsable
{
    [SerializeField] private int healAmount = 30;

    public void Use(PlayerHealth user)
    {
        user.Heal(healAmount);
        Destroy(gameObject);
    }
}

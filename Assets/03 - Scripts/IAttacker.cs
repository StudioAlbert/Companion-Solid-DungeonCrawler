public interface IAttacker
{
    float AttackRange { get; }
    float AttackCooldown { get; }
    void Attack(PlayerHealth player);
}

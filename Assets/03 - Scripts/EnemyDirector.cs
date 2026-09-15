using System.Collections.Generic;
using UnityEngine;

// Fait agir chaque ennemi selon ce qu'il sait faire, sans connaître son type.
public class EnemyDirector : MonoBehaviour
{
    private readonly List<IMovable> movers = new List<IMovable>();
    private readonly List<IAttacker> attackers = new List<IAttacker>();
    private readonly Dictionary<IAttacker, float> nextAttackTimes = new Dictionary<IAttacker, float>();
    private PlayerHealth player;

    void Start()
    {
        foreach (MonoBehaviour behaviour in FindObjectsByType<MonoBehaviour>())
        {
            if (behaviour is IMovable mover) movers.Add(mover);
            if (behaviour is IAttacker attacker) attackers.Add(attacker);
        }
        player = FindAnyObjectByType<PlayerHealth>();
    }

    void Update()
    {
        if (player == null) return;

        // Un ennemi détruit n'est « null » qu'une fois vu comme objet Unity
        movers.RemoveAll(mover => (Object)mover == null);
        attackers.RemoveAll(attacker => (Object)attacker == null);

        foreach (IMovable mover in movers)
            mover.Move(player.transform.position);

        foreach (IAttacker attacker in attackers)
        {
            // Tous les attaquants du donjon sont des composants : ils ont une position
            Vector3 position = ((Component)attacker).transform.position;
            float distance = Vector2.Distance(position, player.transform.position);
            nextAttackTimes.TryGetValue(attacker, out float nextAttack);
            if (distance <= attacker.AttackRange && Time.time >= nextAttack)
            {
                attacker.Attack(player);
                nextAttackTimes[attacker] = Time.time + attacker.AttackCooldown;
            }
        }
    }
}

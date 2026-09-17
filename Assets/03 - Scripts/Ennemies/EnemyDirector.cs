using System.Collections.Generic;
using UnityEngine;

// Fait agir chaque ennemi de la salle.
public class EnemyDirector : MonoBehaviour
{
    private readonly List<Enemy> enemies = new List<Enemy>();
    private readonly Dictionary<Enemy, float> nextAttackTimes = new Dictionary<Enemy, float>();
    private PlayerController player;

    void Start()
    {
        enemies.AddRange(FindObjectsByType<Enemy>());
        player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (player == null) return;
        enemies.RemoveAll(enemy => enemy == null);

        foreach (Enemy enemy in enemies)
        {
            enemy.Move(player.transform.position);

            // Le baril hérite d'Attack mais ne peut pas attaquer
            if (enemy is ExplodingBarrel) continue;

            float distance = Vector2.Distance(enemy.transform.position, player.transform.position);
            nextAttackTimes.TryGetValue(enemy, out float nextAttack);
            if (distance <= enemy.AttackRange && Time.time >= nextAttack)
            {
                enemy.Attack(player);
                nextAttackTimes[enemy] = Time.time + enemy.AttackCooldown;
            }
        }
    }
}

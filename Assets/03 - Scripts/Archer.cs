using UnityEngine;

public class Archer : Enemy
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float arrowSpeed = 6f;

    // Un archer tire depuis son poste : il ne se déplace pas
    public override void Move(Vector3 target) { }

    public override void Attack(PlayerHealth player)
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Le sprite de la flèche pointe vers le haut
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0f, 0f, angle - 90f));
        arrow.GetComponent<Rigidbody2D>().linearVelocity = direction * arrowSpeed;
    }
}

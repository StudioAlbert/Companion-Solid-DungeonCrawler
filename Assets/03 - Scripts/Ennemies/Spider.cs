using System.Collections;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float detectionRadius = 4f;
    [SerializeField] private Collider2D bite;   // zone de morsure, taguée « Spider »

    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        bite.enabled = false;
    }

    // Poursuit le héros quand il est assez proche
    public override void Move(Vector3 target)
    {
        Vector2 toTarget = target - transform.position;
        float distance = toTarget.magnitude;
        bool chasing = distance < detectionRadius && distance > 0.7f;
        body.linearVelocity = chasing ? toTarget.normalized * speed : Vector2.zero;
    }

    public override void Attack(PlayerController player)
    {
        StartCoroutine(Bite());
    }

    // La morsure active brièvement la zone de dégâts
    private IEnumerator Bite()
    {
        bite.enabled = true;
        yield return new WaitForSeconds(0.15f);
        bite.enabled = false;
    }
}

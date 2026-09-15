using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private InputAction moveAction;

    // Dernière direction de déplacement, utilisée pour viser
    public Vector2 Facing { get; private set; } = Vector2.right;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        body.linearVelocity = input * speed;
        if (input == Vector2.zero) return;

        Facing = input.normalized;
        if (input.x != 0) spriteRenderer.flipX = input.x < 0;
    }
}

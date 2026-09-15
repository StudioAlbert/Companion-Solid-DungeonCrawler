using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float fireballSpeed = 8f;

    private PlayerMovement movement;
    private InputAction attackAction;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Boule de feu dans la direction du dernier déplacement
    void Update()
    {
        if (!attackAction.WasPressedThisFrame()) return;

        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody2D>().linearVelocity = movement.Facing * fireballSpeed;
    }
}

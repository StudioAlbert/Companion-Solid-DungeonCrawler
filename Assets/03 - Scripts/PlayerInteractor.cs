using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactRadius = 1f;

    private PlayerHealth health;
    private InputAction interactAction;

    void Awake()
    {
        health = GetComponent<PlayerHealth>();
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    // On parle à ce qui sait parler, on utilise ce qui s'utilise
    void Update()
    {
        if (!interactAction.WasPressedThisFrame()) return;

        foreach (Collider2D hit in Physics2D.OverlapCircleAll(transform.position, interactRadius))
        {
            if (hit.TryGetComponent(out ITalkable talkable)) talkable.Talk();
            if (hit.TryGetComponent(out IUsable usable)) usable.Use(health);
        }
    }
}

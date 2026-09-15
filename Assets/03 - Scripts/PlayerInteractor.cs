using System.Collections.Generic;
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

    // On parle à tout ce qui est proche, et on utilise tout ce qui est proche
    void Update()
    {
        if (!interactAction.WasPressedThisFrame()) return;

        var reached = new HashSet<IEntity>();
        foreach (Collider2D hit in Physics2D.OverlapCircleAll(transform.position, interactRadius))
        {
            if (hit.TryGetComponent(out IEntity entity) && entity != (IEntity)health && reached.Add(entity))
            {
                entity.Talk();
                entity.Use(health);
            }
        }
    }
}

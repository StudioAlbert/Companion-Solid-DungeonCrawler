using UnityEngine;

// La plaque ne connaît qu'un contrat : n'importe quel mécanisme activable.
public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject target;   // doit porter un composant ISwitchable
    [SerializeField] private Color idleColor = new Color(0.78f, 0.78f, 0.85f);
    [SerializeField] private Color activeColor = new Color(0.55f, 0.85f, 0.6f);

    private ISwitchable switchable;
    private SpriteRenderer spriteRenderer;
    private bool isOn;

    void Awake()
    {
        switchable = target.GetComponent<ISwitchable>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = idleColor;
    }

    // Signale dès l'éditeur une cible qui ne peut pas être actionnée
    void OnValidate()
    {
        if (target != null && target.GetComponent<ISwitchable>() == null)
            Debug.LogWarning(target.name + " n'implémente pas ISwitchable : la plaque ne pourra pas l'actionner", this);
    }

    // Chaque passage sur la plaque inverse son état
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isOn = !isOn;
        spriteRenderer.color = isOn ? activeColor : idleColor;

        if (isOn) switchable.Activate();
        else switchable.Deactivate();
    }
}

using UnityEngine;

public class Door : MonoBehaviour, ISwitchable
{
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openSprite;

    private SpriteRenderer spriteRenderer;
    private Collider2D doorCollider;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();
    }

    // Ouvre la porte
    public void Activate()
    {
        spriteRenderer.sprite = openSprite;
        doorCollider.enabled = false;
    }

    // Ferme la porte
    public void Deactivate()
    {
        spriteRenderer.sprite = closedSprite;
        doorCollider.enabled = true;
    }
}

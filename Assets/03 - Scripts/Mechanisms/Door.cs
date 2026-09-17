using UnityEngine;

public class Door : MonoBehaviour
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

    public void Open()
    {
        spriteRenderer.sprite = openSprite;
        doorCollider.enabled = false;
    }

    public void Close()
    {
        spriteRenderer.sprite = closedSprite;
        doorCollider.enabled = true;
    }
}

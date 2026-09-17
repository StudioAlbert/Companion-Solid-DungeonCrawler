using UnityEngine;

// La plaque connaît directement chaque mécanisme qu'elle peut actionner.
public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private WallFountain fountain;
    [SerializeField] private Color idleColor = new Color(0.78f, 0.78f, 0.85f);
    [SerializeField] private Color activeColor = new Color(0.55f, 0.85f, 0.6f);

    private SpriteRenderer spriteRenderer;
    private bool isOn;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = idleColor;
    }

    // Chaque passage sur la plaque inverse son état
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isOn = !isOn;
        spriteRenderer.color = isOn ? activeColor : idleColor;

        if (door != null)
        {
            if (isOn) door.Open();
            else door.Close();
        }
        if (fountain != null)
        {
            if (isOn) fountain.TurnOn();
            else fountain.TurnOff();
        }
    }
}

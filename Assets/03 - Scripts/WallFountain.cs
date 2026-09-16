using UnityEngine;

public class WallFountain : MonoBehaviour, ISwitchable
{
    [SerializeField] private Sprite dryFountain;
    [SerializeField] private Sprite flowingFountain;
    [SerializeField] private SpriteRenderer basin;
    [SerializeField] private Sprite emptyBasin;
    [SerializeField] private Sprite fullBasin;

    private SpriteRenderer fountain;

    void Awake()
    {
        fountain = GetComponent<SpriteRenderer>();
    }

    // L'eau coule
    public void Activate()
    {
        fountain.sprite = flowingFountain;
        basin.sprite = fullBasin;
    }

    // La fontaine se tarit
    public void Deactivate()
    {
        fountain.sprite = dryFountain;
        basin.sprite = emptyBasin;
    }
}

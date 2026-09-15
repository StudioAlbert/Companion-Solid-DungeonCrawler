using UnityEngine;

public class WallFountain : MonoBehaviour
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

    public void TurnOn()
    {
        fountain.sprite = flowingFountain;
        basin.sprite = fullBasin;
    }

    public void TurnOff()
    {
        fountain.sprite = dryFountain;
        basin.sprite = emptyBasin;
    }
}

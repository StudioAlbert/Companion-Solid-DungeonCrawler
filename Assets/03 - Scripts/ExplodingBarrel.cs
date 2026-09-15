using UnityEngine;

// Le baril ne promet que ce qu'il sait faire : prendre des dégâts, et exploser.
public class ExplodingBarrel : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject explosionPrefab;

    public void TakeDamage(int amount)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

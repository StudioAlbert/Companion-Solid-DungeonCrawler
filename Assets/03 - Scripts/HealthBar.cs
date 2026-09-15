using TMPro;
using UnityEngine;

// Affichage des points de vie : ne sait rien des dégâts ni des soins.
public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    public void Show(int health)
    {
        label.text = "PV : " + health;
    }
}

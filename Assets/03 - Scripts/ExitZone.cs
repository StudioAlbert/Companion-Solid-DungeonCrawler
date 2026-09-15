using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZone : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private float reloadDelay = 3f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        other.gameObject.SetActive(false);   // le héros a quitté la salle
        victoryPanel.SetActive(true);
        Invoke(nameof(Reload), reloadDelay);
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

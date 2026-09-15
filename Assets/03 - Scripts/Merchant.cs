using UnityEngine;

public class Merchant : MonoBehaviour, IEntity
{
    private AudioSource voice;   // le jingle est réglé sur l'AudioSource

    void Awake()
    {
        voice = GetComponent<AudioSource>();
    }

    public void Talk()
    {
        voice.Play();
    }

    // Imposées par IEntity
    public void Move(Vector3 target) { }
    public void Attack(PlayerHealth player) { }   // un marchand n'attaque pas
    public void TakeDamage(int amount) { }        // invulnérable
    public void Use(PlayerHealth user) { }
}

using UnityEngine;

public class Merchant : MonoBehaviour, ITalkable
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
}

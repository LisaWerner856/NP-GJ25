using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("Audio source")]
    [SerializeField] AudioSource musicSource;

    
    [Header("Audio Clip")]
    public AudioClip background;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}

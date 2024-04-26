using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Instancia estática del SoundManager para facilitar el acceso desde otros scripts
    public static SoundManager instance;

    // Agrega aquí todos los sonidos que desees reproducir
    public AudioClip[] soundClips;

    // Componente de audio para reproducir los sonidos
    private AudioSource audioSource;

    private void Awake()
    {
        // Garantiza que solo haya una instancia del SoundManager en el juego
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Obtén o agrega un componente de AudioSource al objeto
        audioSource = GetComponent<AudioSource>();

        // Opcional: puedes configurar aquí las preferencias del AudioSource (volumen, etc.)
    }

    // Método para reproducir un sonido específico
    public void PlaySound(AudioClip sound)
    {
            // Reproduce el sonido correspondiente
            audioSource.PlayOneShot(sound);
            
    }
}

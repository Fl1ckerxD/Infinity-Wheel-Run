using UnityEngine;

public class Audio : MonoBehaviour
{
    /// <summary>
    /// Игровые звуки
    /// </summary>
    public AudioClip[] clips;
    private AudioSource _audios;

    // Кэширование аудио
    private void Start()
    {
        _audios = GetComponent<AudioSource>();
    }

    // Воспроизведение звука
    public void Effects(int i)
    {
        _audios.PlayOneShot(clips[i]);
    }
}

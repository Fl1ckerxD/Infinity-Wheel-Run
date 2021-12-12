using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    /// <summary>
    /// UI объекты
    /// </summary>
    [SerializeField] private Slider music;
    [SerializeField] private Slider effects;

    [SerializeField] private AudioMixerGroup mixerGroup;

    // Установка уровни громкости
    private void Start()
    {
        music.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        effects.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);
    }

    // Регулирование громкости музыки
    public void MusicVolume(float musicVol)
    {
        mixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, musicVol));
        PlayerPrefs.SetFloat("MusicVolume", musicVol);
    }

    // Регулирование громкости эффектов
    public void EffectsVolume(float effectsVol)
    {
        mixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, effectsVol));
        PlayerPrefs.SetFloat("EffectsVolume", effectsVol);
    }
}

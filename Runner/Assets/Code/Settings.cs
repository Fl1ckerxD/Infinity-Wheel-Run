using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider music;
    [SerializeField] private Slider effects;

    [SerializeField] private AudioMixerGroup mixerGroup;
    private void Start()
    {
        music.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        effects.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);
    }
    public void MusicVolume(float musicVol)
    {
        mixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, musicVol));
        PlayerPrefs.SetFloat("MusicVolume", musicVol);
    }
    public void EffectsVolume(float effectsVol)
    {
        mixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, effectsVol));
        PlayerPrefs.SetFloat("EffectsVolume", effectsVol);
    }
}

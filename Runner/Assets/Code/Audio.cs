using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audios;
    private void Start()
    {
        audios = GetComponent<AudioSource>();
    }
    public void Effects(int i)
    {
        audios.PlayOneShot(clips[i]);
    }
}

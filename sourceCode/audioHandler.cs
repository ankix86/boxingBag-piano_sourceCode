using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioHandler : MonoBehaviour
{
    public AudioClip boxing;
    public AudioClip buzzer;
    public AudioClip[] cutingEffect;
    public AudioClip[] audioClip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();
      
    }
    public AudioClip[] getCuttingFX()
    {
        return cutingEffect;
    }
    
}

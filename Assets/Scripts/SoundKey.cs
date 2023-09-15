using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKey : MonoBehaviour
{
    [SerializeField] AudioClip keySound;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = keySound;
    }

    public void PlayKey()
    {
        source.Play();
    }


}

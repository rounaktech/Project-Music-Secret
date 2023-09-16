using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKey : MonoBehaviour
{
    [SerializeField] AudioClip keySound;
    AudioSource source;
    AnswerManager ans;
    [SerializeField] string KeySoundString;

    private void Awake()
    {
        ans = AnswerManager.Instance;
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = keySound;
    }

    public void PlayKey()
    {
        source.Play();
    }

    public void AddKey()
    { 
        ans.KeyStringAdder(KeySoundString);
    }

}

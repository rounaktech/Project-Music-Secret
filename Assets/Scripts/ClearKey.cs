using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearKey : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void ClearAnswer()
    {
        source.Play();
        AnswerManager.Instance.NoteAnswer = "";
    }
}

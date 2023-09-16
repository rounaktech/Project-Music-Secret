using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gramophone : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] TMP_Text eToEnter;
    public string FinalAnswerString = "";
    bool isActive = false;

    private void Update()
    {
        if(Input.GetKeyDown(GlobalConstants.INTERACTKEY) && isActive)
        {
            sound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        eToEnter.text = "Press E To Play";
        isActive = true;
        AnswerManager.Instance.finalAnswer = FinalAnswerString;
    }

    private void OnTriggerExit(Collider other)
    {
        eToEnter.text = "";
        isActive = false;
    }
}

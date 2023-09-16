using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buzzer : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] TMP_Text eToEnter;
    bool isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(GlobalConstants.INTERACTKEY) && isActive)
        {
            sound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        eToEnter.text = "Press E To Confirm";
        isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        eToEnter.text = "";
        isActive = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] GameObject eToEnter;
    [SerializeField] GameObject readableNote;
    [SerializeField] TMP_Text noteText;
    public bool IsReadingNote = false;
  
    private void Awake()
    {
        Instance = this;
    }

    public void ReadNoteChecker(string myNote)
    {  
        if (!IsReadingNote && (eToEnter.activeInHierarchy == true))
        {
            IsReadingNote = true;
            readableNote.SetActive(true);
            noteText.text = myNote;
            eToEnter.SetActive(false);
            Time.timeScale = 0;
        }
        else if (IsReadingNote && (eToEnter.activeInHierarchy == false))
        {
            IsReadingNote = false;
            readableNote.SetActive(false);
            eToEnter.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void EToEnterState(bool state)
    {
        eToEnter.SetActive(state);
    }
}

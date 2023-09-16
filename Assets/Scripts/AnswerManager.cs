using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnswerManager : MonoBehaviour
{
    public static AnswerManager Instance;
    public string finalAnswer = "C#ADB";
    public string NoteAnswer = "";
    [SerializeField] TMP_Text sequenceShow;
    private void Awake()
    {
        Instance = this;
    }

    public void KeyStringAdder(string keyNote)
    {
        NoteAnswer += keyNote;
    }

    void Update()
    {
        sequenceShow.text = "Sequence \n" + NoteAnswer;
        if(finalAnswer.Length == NoteAnswer.Length)
        {
            if(finalAnswer == NoteAnswer)
            {
                NoteAnswer = "";
            }
            else if(finalAnswer != NoteAnswer)
            {
                Debug.Log("Wrong Answer");
                NoteAnswer = "";
            }
        }
        else if(finalAnswer.Length < NoteAnswer.Length)
        {
            Debug.Log("Wrong Answer");
            NoteAnswer = "";
        }
    }
}

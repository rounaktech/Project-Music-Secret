using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public string myNote;
    bool isTouchingPlayer = false;
    PlayerMovement player;
    bool isLooking = false;
    private void Start()
    {
        player = GameManager.Instance.Player;
    }
    void Update()
    {
        keyBoolSwitch();
        Looking();
    }

    void keyBoolSwitch()
    {
        if ((Input.GetKeyDown(GlobalConstants.INTERACTKEY) || Input.GetButtonDown(GlobalConstants.INTERACTKEYJOY)) && isTouchingPlayer && isLooking)
        {
            NoteManager.Instance.ReadNoteChecker(myNote);
        }
    }
    
    void Looking()
    {
        if (isTouchingPlayer)
        {
            float dotProd = Vector3.Dot(player.transform.forward, Vector3.Normalize(transform.position - player.transform.position));
            if (dotProd > 0.6)
            {
                isLooking = true;
                if(!NoteManager.Instance.IsReadingNote)
                    NoteManager.Instance.EToEnterState(true);
                else
                    NoteManager.Instance.EToEnterState(false);
            }
            else
            {
                isLooking = false;
                NoteManager.Instance.EToEnterState(false);
            }
        }    
    }
    
    //Triggers
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals(GlobalConstants.TAG_PLAYER))
        {
            isTouchingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(GlobalConstants.TAG_PLAYER))
        {
            isTouchingPlayer = false;
            NoteManager.Instance.EToEnterState(false);
        }
    }
}

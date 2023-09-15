using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] bool dead = false;
    PlayerMovement playerref;
    [SerializeField] Transform restartPoint;

    private void Start()
    {
        playerref = GameManager.Instance.Player;
    }

    private void Update()
    {
        if(dead)
        {
            playerref.LerperStarter(restartPoint);
        }
    }


}

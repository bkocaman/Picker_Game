using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameManager gameManager;
    PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }


    void OnTriggerEnter()
    {
            GetComponent<GameManager>().endgame = true;
    }
}

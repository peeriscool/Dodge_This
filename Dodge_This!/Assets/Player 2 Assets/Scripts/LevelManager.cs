using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // References
    ObjectSpawning objectSpawning;
    public GameObject dodgingPlayer;
    public GameObject dodgingPlayer1;
    public GameObject dodgingPlayer2;
    public GameObject dodgingPlayer3;
    // Level state
    public bool levelActive = false;
    public int playerThatWon = 0; // 0 = No one has won (yet)
    // Player amount
    public int players = 1;
    private void Start()
    {
        dodgingPlayer1.SetActive(false);
        dodgingPlayer2.SetActive(false);
        dodgingPlayer3.SetActive(false);
    }
    void Update()
    {
        // Enabling and disabling dodging players
        EnableDisablePlayerObjects();
    }

    void EnableDisablePlayerObjects()
    {
        // Fine spaghetti
        if (players == 1)
        {
            dodgingPlayer.SetActive(true);
            dodgingPlayer1.SetActive(false);
            dodgingPlayer2.SetActive(false);
            dodgingPlayer3.SetActive(false);
        }
        else if (players == 2)
        {
            dodgingPlayer.SetActive(true);
            dodgingPlayer1.SetActive(true);
            dodgingPlayer2.SetActive(false);
            dodgingPlayer3.SetActive(false);
        }
        else if (players == 3)
        {
            dodgingPlayer.SetActive(true);
            dodgingPlayer1.SetActive(true);
            dodgingPlayer2.SetActive(true);
            dodgingPlayer3.SetActive(false);
        }
        else if (players == 4)
        {
            dodgingPlayer.SetActive(true);
            dodgingPlayer1.SetActive(true);
            dodgingPlayer2.SetActive(true);
            dodgingPlayer3.SetActive(true);
        }
    }
}

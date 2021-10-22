using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // References
    public PlaceOnSongBeat song;
    public GameObject dodgingPlayer;
    public GameObject dodgingPlayer1;
    public GameObject dodgingPlayer2;
    public GameObject dodgingPlayer3;
    public PlayerHP playerHP;
    public PlayerHP playerHP1;
    public PlayerHP playerHP2;
    public PlayerHP playerHP3;
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
        // Dodgingplayers lose
        if (players == 1)
        {
            if (playerHP.playerDead)
            {
                song.stopSong = true;
            }
        } else if (players == 2)
        {
            if (playerHP.playerDead && playerHP1.playerDead)
            {
                song.stopSong = true;
            }
        } else if (players == 3)
        {
            if (playerHP.playerDead && playerHP1.playerDead && playerHP2.playerDead)
            {
                song.stopSong = true;
            }
        } else if (players == 4)
        {
            if (playerHP.playerDead && playerHP1.playerDead && playerHP2.playerDead && playerHP3.playerDead)
            {
                song.stopSong = true;
            }
        }
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

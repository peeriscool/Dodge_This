using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Script references
    public LevelManager levelManager;
    public PlaceOnSongBeat song;
    // UIHolder references
    public GameObject menuUIHolder;
    public GameObject gameUIHolder;
    public GameObject gameUIHolder1;
    // Menu 
    public TMP_Text playerCountText;
    // Song select
    public TMP_Text bpm;
    public TMP_Text songName;
    // Endscreen
    public Canvas kinectCanvas;
    public GameObject endUIHolder;
    public TMP_Text endText;
    private void Start()
    {
        menuUIHolder.gameObject.SetActive(true);
        gameUIHolder.gameObject.SetActive(false);
        gameUIHolder1.gameObject.SetActive(false);
        endUIHolder.gameObject.SetActive(false);
    }
    void Update()
    {
        // Locking cursor
        if (levelManager.levelActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        playerCountText.text = "Dodgers: " + levelManager.players;
        songName.text = song.songName;
        bpm.text = song.averageBPM.ToString();

        // Game over / win
        if (song.stopSong)
        {
            endText.text = "Kinect player wins!";
            endUIHolder.gameObject.SetActive(true);
        }
        if (song.songComplete)
        {
            endText.text = "Doding players win!";
            endUIHolder.gameObject.SetActive(true);
        }
        if (levelManager.players <= 2)
        {
            kinectCanvas.targetDisplay = 1;
        }
        else if (levelManager.players >= 3)
        {
            kinectCanvas.targetDisplay = 2;
        }
    }
    public void StartLevel()
    {
        levelManager.levelActive = true;
        menuUIHolder.gameObject.SetActive(false);
        gameUIHolder.gameObject.SetActive(true);
        gameUIHolder1.gameObject.SetActive(true);
    }
    public void MinusOnePlayer()
    {
        if (levelManager.players > 1)
        {
            levelManager.players-=1;
        }
    }
    public void PlusOnePlayer()
    {
        if (levelManager.players < 4)
        {
            levelManager.players+=1;
        }
    }
    public void MinusOneSong()
    {
        if (song.songIndex > 0)
        {
            song.songIndex -= 1;
        }
    }
    public void PlusOneSong()
    {
        if (song.songIndex < 3)
        {
            song.songIndex += 1;
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

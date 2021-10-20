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
    // UIHolder references
    public GameObject menuUIHolder;
    public GameObject gameUIHolder;
    // Menu 
    public TMP_Text playerCountText;
    private void Start()
    {
        menuUIHolder.gameObject.SetActive(true);
        gameUIHolder.gameObject.SetActive(false);
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
    }
    public void StartLevel()
    {
        levelManager.levelActive = true;
        menuUIHolder.gameObject.SetActive(false);
        gameUIHolder.gameObject.SetActive(true);
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
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Script references
    public LevelManager levelManager;
    // UIHolder references
    public GameObject menuUIHolder;
    public GameObject gameUIHolder;
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
    }
    public void StartLevel()
    {
        levelManager.levelActive = true;
        menuUIHolder.gameObject.SetActive(false);
        gameUIHolder.gameObject.SetActive(true);
    }
}

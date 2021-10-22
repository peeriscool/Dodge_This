using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiScreenActivation : MonoBehaviour
{
    public LevelManager levelManager;
    public UI ui;
    public GameObject bottomPlayer1UI;
    public GameObject bottomPlayer3UI;
    public Camera kinectPlayer;
    public Camera mainScreen;
    public Camera mainScreen1;
    public Camera secondScreen;
    public Camera secondScreen1;
    void Start()
    {
        // Start with all false
        mainScreen1.gameObject.SetActive(false);
        secondScreen.gameObject.SetActive(false);
        secondScreen1.gameObject.SetActive(false);
        bottomPlayer1UI.SetActive(false);
        bottomPlayer3UI.SetActive(false);

        for(int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate(1920,1080,60);
        }
    }
    private void Update()
    {
        if (levelManager.players == 1)
        {
            SplitTopCam(false, mainScreen);
            BottomPlayerUI(false, bottomPlayer1UI);
        }
        else if (levelManager.players == 2)
        {
            mainScreen1.gameObject.SetActive(true);
            secondScreen.gameObject.SetActive(false);
            secondScreen1.gameObject.SetActive(false);
            SplitTopCam(true, mainScreen);
            kinectPlayer.targetDisplay = 1;
            BottomPlayerUI(true, bottomPlayer1UI);
            BottomPlayerUI(false, bottomPlayer3UI);
        } else if (levelManager.players == 3)
        {
            secondScreen.gameObject.SetActive(true);
            SplitTopCam(false, secondScreen);
            kinectPlayer.targetDisplay = 2;
            BottomPlayerUI(true, bottomPlayer3UI);
        } else if (levelManager.players == 4)
        {
            SplitTopCam(true, secondScreen);
            secondScreen1.gameObject.SetActive(true);
        }

        if (levelManager.song.stopSong)
        {

        }
    }
    void SplitTopCam(bool split, Camera topCamera)
    {
        if (split)
        {
            topCamera.rect = new Rect(0, 0.5f, 1, 0.5f);
        } else
        {
            topCamera.rect = new Rect(0, 0, 1, 1);
        }
    }
    public void BottomPlayerUI(bool enable, GameObject bottomUIHolder)
    {
        if (enable == true)
        {
            bottomUIHolder.SetActive(true);
        }
        else if (enable == false)
        {
            bottomUIHolder.SetActive(false);
        }
    }
}

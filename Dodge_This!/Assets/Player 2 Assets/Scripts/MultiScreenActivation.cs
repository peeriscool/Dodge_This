using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiScreenActivation : MonoBehaviour
{
    public LevelManager levelManager;
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
        }
        else if (levelManager.players == 2)
        {
            mainScreen1.gameObject.SetActive(true);
            secondScreen.gameObject.SetActive(false);
            secondScreen1.gameObject.SetActive(false);
            SplitTopCam(true, mainScreen);
            kinectPlayer.targetDisplay = 1;

        } else if (levelManager.players == 3)
        {
            secondScreen.gameObject.SetActive(true);
            SplitTopCam(false, secondScreen);
            kinectPlayer.targetDisplay = 2;
        } else if (levelManager.players == 4)
        {
            SplitTopCam(true, secondScreen);
            secondScreen1.gameObject.SetActive(true);
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
}

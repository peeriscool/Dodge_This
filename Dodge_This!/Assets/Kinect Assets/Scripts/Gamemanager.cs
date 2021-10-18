using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    protected CameraviewportScript cameraviewport;
    public Camera[] cameras;
    // Start is called before the first frame update
    void Start()
    {
             cameraviewport.firstPersonCamera = cameras[0];
             cameraviewport.overheadCamera = cameras[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            cameraviewport.ShowFirstPersonView();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            cameraviewport.ShowOverheadView();
        }
    }
}

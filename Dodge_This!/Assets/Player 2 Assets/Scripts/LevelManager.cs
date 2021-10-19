using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject spawnable;
    ObjectSpawning objectSpawning;
    public bool levelActive = false;
    void Start()
    {
        objectSpawning = new ObjectSpawning(spawnable);
        objectSpawning.localTrigger = levelActive;
    }

    void Update()
    {
        objectSpawning.Tick();
    }
}

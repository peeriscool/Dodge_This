using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    // References
    public LevelManager levelManager;
    // TEMP SPAWNING FOR TESTING
    public GameObject spawnableShape;
    public bool isSpawning = false;
    /*public ObjectSpawning(GameObject _shootShape)
    {
        shootShape = _shootShape;
    }*/
    void Update()
    {

    }
    public void SpawnObject()
    {
        Instantiate(spawnableShape, transform.position, transform.rotation);
    }
}

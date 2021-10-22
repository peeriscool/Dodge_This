using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    // References
    public LevelManager levelManager;
    // TEMP SPAWNING FOR TESTING
    public GameObject spawnableShape;
    /*public ObjectSpawning(GameObject _shootShape)
    {
        shootShape = _shootShape;
    }*/
    
    public void SpawnObject()
    {
        Instantiate(spawnableShape, transform.position, transform.rotation);
    }
}

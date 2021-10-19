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
        // SPAWN FOR TESTING 
        if (isSpawning == false && levelManager.levelActive)
        { 
            { 
                StartCoroutine(SpawnObjectOnRythm());
                isSpawning = true;
            }
        } 
    }
    IEnumerator SpawnObjectOnRythm()
    { 
        yield return new WaitForSeconds(1);
        print("Spawned tempshape");
        Instantiate(spawnableShape, transform.position, transform.rotation);
        //Keep spawning while game is active
        if (isSpawning == true)
        {
            StartCoroutine(SpawnObjectOnRythm());
        }
    }
}

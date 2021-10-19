using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    // TEMP SPAWNING FOR TESTING
    public GameObject shootShape;
    public bool localTrigger = false;
    public ObjectSpawning(GameObject _shootShape) //empty construct
    {
        shootShape = _shootShape;
    }
    public void Tick()
    {
        // SPAWN FOR TESTING 
        if (localTrigger)
        { 
            { 
                StartCoroutine(SpawnObjectOnRythm());
                localTrigger = false;
            }
        }
    }
    IEnumerator SpawnObjectOnRythm()
    { 
        yield return new WaitForSeconds(1);
        print("kaas");
        localTrigger = true;
    }
}

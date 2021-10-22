using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawningKinect : MonoBehaviour
{
    // References
    public LevelManager levelManager;
    // TEMP SPAWNING FOR TESTING
    public GameObject spawnableShape;
    GameObject[] Kinectshapes;
    /*public ObjectSpawning(GameObject _shootShape)
    {
        shootShape = _shootShape;
    }*/

    public void kinectshapesLoad(GameObject[] _Kinectshapes)
    {
        Kinectshapes = _Kinectshapes;
    }
    public void kinectshapesadd(GameObject _Kinectshapes) // make sure to add shapes as a component before adding!
    {
        Kinectshapes[Kinectshapes.Length] = _Kinectshapes;
    }
    public GameObject[] kinectshapesGet()
    {
        if(Kinectshapes != null)
        {
            return Kinectshapes;
        }
        return null;
    }
    public void SpawnObject()
    {
        Instantiate(spawnableShape, transform.position, transform.rotation);
    }
    public void SpawnObjectKinect()
    {
        Instantiate(Kinectshapes[Kinectshapes.Length], transform.position, transform.rotation); //spawn last object in array
        Kinectshapes = Kinectshapes.Take(Kinectshapes.Length - 1).ToArray(); //remove last
            //array = array.Take(array.Length - 1).ToArray();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshManager
{
    // Start is called before the first frame update
    public static List<Vector3> spawnpoints;
    private static List<List<Vector3>> DataBank; //keeps track of every 4 vector3 parsed

    // Static constructor is called at most one time, before any
    // instance constructor is invoked or member is accessed.
    static MeshManager()
    {
        spawnpoints = new List<Vector3>();
        DataBank = new List<List<Vector3>>();
    }
    public static List<Vector3> GetSpawnPoints()
    {
        return spawnpoints;
    }
    public static void AddSpawnPoints(Vector3 _spawnpoint)
    {
        spawnpoints.Add(_spawnpoint);
    }
    public static void SetSpawnPoints(List<Vector3> _spawnpoint)
    {
        spawnpoints = _spawnpoint;
    }
    public static bool Check()
    {
        if (spawnpoints.Count == 8) //make vertex
        {
            Debug.Log("we found 4 points for a mesh reseting and storing data");
            DataBank.Add(spawnpoints);
            return true;
        }
        else return false;
    }
    public static void Flush() //reset the list
    {
        spawnpoints = new List<Vector3>();
    }
    // Update is called once per frame
    private static void Logic_One()
    {
        
    }
}

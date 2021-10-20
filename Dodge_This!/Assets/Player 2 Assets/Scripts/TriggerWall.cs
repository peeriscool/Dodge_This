using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    // References
    public DodgingPlayer dg;

    private void OnTriggerEnter(Collider other)
    {
        //print(other.tag);
        // When shape in back wall trigger
        if (other.tag == "Shape")
        {
            //print("Shape in back wall trigger");
            Destroy(other.gameObject);
        }
    }
}

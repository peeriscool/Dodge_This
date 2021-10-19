using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    // References
    public DodgingPlayer dg;
    // Vars
    public bool frontWall = false;

    void OnTriggerStay(Collider other)
    {
        // When player in trigger
        if (other.tag == "Player")
        {
            // Front or back wall, cant walk forward/back
            if (frontWall == true)
            {
                dg.cantWalkForward = true;
                dg.isInInvisibleWall = true;
            }
            else if (frontWall == false)
            {
                dg.cantWalkForward = false;
                dg.isInInvisibleWall = true;
            }
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        // When shape in back wall trigger
        if (other.tag == "Shape" && frontWall == false)
        {
            print("Shape in back wall trigger");
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When player gets out of trigger
        if (other.tag == "Player")
        {
            // Stop movement limitations in playerscript
            dg.isInInvisibleWall = false;
        }
    }
}

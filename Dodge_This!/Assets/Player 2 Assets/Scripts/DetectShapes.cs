using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShapes : MonoBehaviour
{
    // References
    public DodgingPlayer dodgingPlayer;
    public PlayerHP playerHP;
    void Start()
    {
        dodgingPlayer = GetComponentInParent<DodgingPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // Getting hit by a shape
        Debug.Log(other.GetType());
        if (other.tag == "Shape")
        {
            print("HIT BY SHAPE");
            if (playerHP.canTakeDamage)
            {
                playerHP.hit = true;
            }
        }
    }
}

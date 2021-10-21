using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    // References
    public DodgingPlayer dodgingPlayer;
    public List<GameObject> hitpoints;
    public GameObject playerGFX;
    GameObject hpToRemove;
    // Health and damage
    public bool hit = false;
    public bool canTakeDamage = true;
    public float invulnerabilityTime = 2f;
    public bool playerDead = false;
    private void Start()
    {
        canTakeDamage = true;
    }
    private void Update()
    {
        for (int i = 0; i < hitpoints.Count; i++) 
        {
            if (hit)
            {
                hpToRemove = hitpoints[hitpoints.Count - 1];
                //print(hitpoints.Capacity);
                hitpoints.Remove(hitpoints[(hitpoints.Count - 1)]);
                Animation hpAnimation = hpToRemove.GetComponent<Animation>();
                hpAnimation.Play("RemoveHP");
                print("-1 HP");
                if (hitpoints.Count == 0)
                {
                    print("u dead doe");
                    playerDead = true;
                    Destroy(playerGFX);
                } else
                {
                    StartCoroutine(InvulnerableWhenHit());
                }
                hit = false;
            }
        }
    }
    IEnumerator InvulnerableWhenHit()
    {
        print("INVULNERABLE");
        // Player hit and invulnerable
        canTakeDamage = false;
        //Start heart deplete animation
        yield return new WaitForSeconds(invulnerabilityTime);
        canTakeDamage = true;
        // Player can take damage again
        print("NOT INVULN");
    }
    public void DestroyHPObject()
    {
        Destroy(playerGFX);
        playerDead = true;
    }
}


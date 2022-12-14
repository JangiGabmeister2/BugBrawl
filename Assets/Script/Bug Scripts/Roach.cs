using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roach : BugAI
{
    public override void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Richard")
        {
            if (Attacks.hitting)
            {
                if (transform.tag == "German Roach")
                {
                    SpawnPointIndicator("<color=white>+10</color>");
                    timerScore.AddPoints(10);
                    alreadyCalled = true;
                }
                else if (transform.tag == "Common Roach")
                {
                    SpawnPointIndicator("<color=white>+7</color>");
                    timerScore.AddPoints(7);
                    alreadyCalled = true;
                }

                screamSFX.Play();
                     
                transform.rotation = collision.gameObject.transform.rotation; //changes bug rotation to player rotation, so when gets shot off, is shot in direction of player look direction

                speed = -500; //sets speed to fly off
            }
        }
    }

}
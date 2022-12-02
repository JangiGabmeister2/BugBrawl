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
                if (transform.name == "GermanRoach")
                {
                    timerScore.AddPoints(10);
                }
                else if (transform.name == "CommonRoach")
                {
                    timerScore.AddPoints(7);
                }

                screamSFX.Play();
                     
                transform.rotation = collision.gameObject.transform.rotation; //changes bug rotation to player rotation, so when gets shot off, is shot in direction of player look direction

                speed = -1000; //sets speed to fly off
            }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : BugAI
{
    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Richard")
        {
            if (Attacks.hitting)
            {
                if (transform.name == "FireAnt")
                {
                    timerScore.AddPoints(2);
                }
                else if (transform.name == "RedAnt")
                {
                    timerScore.AddPoints(5);
                }

                screamSFX.Play();

                transform.rotation = collision.gameObject.transform.rotation; //changes bug rotation to player rotation, so when gets shot off, is shot in direction of player look direction

                speed = -1000; //sets speed to fly off
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBug : BugAI
{
    [SerializeField] Animator walkingAnim;

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Richard")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (transform.tag == "Orange Scorpion")
                {
                    timerScore.AddPoints(100);

                    timerScore.AddTime(5);
                    SpawnPointIndicator("+5s\n<color=yellow>+100</color>");
                    alreadyCalled = true;
                }
                else if (transform.tag == "Golden Scorpion")
                {
                    timerScore.AddPoints(200);

                    timerScore.AddTime(5);
                    SpawnPointIndicator("+5s\n<color=yellow>+200</color>");
                    alreadyCalled = true;
                }

                screamSFX.Play();

                walkingAnim.enabled = false;

                transform.rotation = collision.gameObject.transform.rotation; //changes bug rotation to player rotation, so when gets shot off, is shot in direction of player look direction

                speed = -500; //sets speed to fly off
            }
        }
    }
}

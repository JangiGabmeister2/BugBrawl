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
                timerScore.AddPoints(200);
                timerScore.AddTime(5);

                screamSFX.Play();

                walkingAnim.enabled = false;

                transform.rotation = collision.gameObject.transform.rotation; //changes bug rotation to player rotation, so when gets shot off, is shot in direction of player look direction

                speed = -1000; //sets speed to fly off
            }
        }
    }
}

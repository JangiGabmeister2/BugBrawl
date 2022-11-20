using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roach : BugAI
{
    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Richard")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                screamSFX.Play();
                    
                transform.rotation = collision.gameObject.transform.rotation; //changes bug rotation to player rotation, so when gets shot off, is shot in direction of player look direction

                speed = -1000; //sets speed to fly off

                transform.localScale = Vector3.one * 10f; //changes size
            }
        }
    }
}
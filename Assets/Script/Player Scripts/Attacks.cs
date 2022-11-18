using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [Header("Punch Animation Controllers")]
    [SerializeField] private Animator rightPunch; //animates right arm to punch
    [SerializeField] private Animator leftPunch; //animates left arm to punch

    [Header("Punch SFX")]
    [SerializeField] private AudioSource punchSFX; //sound effect for punch

    [Header("Time/Score Handler")]
    public Timer timerscore;

    float cooldown = 0.1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        cooldown -= Time.deltaTime;
    }

    private void Attack()
    {
        if (MenuHandler.menuHandlerInstance.gameState == GameStates.Game)
        {
            if (cooldown <= 0)
            {
                punchSFX.Play(); //plays punch sfx

                rightPunch.GetComponent<Animator>().Play("RightPunch"); //activates right punch
                leftPunch.GetComponent<Animator>().Play("LeftPunch"); //activates left punch

                cooldown = 0.1f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ant")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                timerscore.AddPoints(5);
            }
        }
        if (collision.gameObject.tag == "Roach")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                timerscore.AddPoints(10);
            }
        }
        if (collision.gameObject.tag == "Pede") //either millipede or centipede
        {
            if (Input.GetKey(KeyCode.Space))
            {
                timerscore.AddPoints(15);
            }
        }
        else if (collision.gameObject.tag == "GoldenBug")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                timerscore.AddPoints(timerscore.score * 2); //doubles score
                timerscore.AddTime(5); //adds 5 seconds when punched
            }
        }
    }
}

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
    public Timer scores;

    float cooldown = 0.5f;

    private void Start()
    {

    }

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

                cooldown = 0.5f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bug")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                scores.AddPoints(10);
            }
        }
    }
}

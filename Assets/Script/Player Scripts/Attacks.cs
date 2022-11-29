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
        if (Input.GetKeyDown(KeyCode.F)) //when player presses the button
        {
            Attack(); //player attacks
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
}

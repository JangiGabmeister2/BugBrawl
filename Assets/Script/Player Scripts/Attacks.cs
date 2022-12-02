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

    public static bool hitting;
    bool hitDone = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !hitting) //when player presses the button
        {
            Attack(); //player attacks

            hitting = true;
            Invoke("NoLongerHitting", .25f);
        }               

        cooldown -= Time.deltaTime;
    }

    void NoLongerHitting()
    {
        hitting = false;
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

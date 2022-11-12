using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField] private Animator rightPunch; //animates right arm to punch
    [SerializeField] private Animator leftPunch; //animates left arm to punch
    [SerializeField] private AudioSource punchSFX; //sound effect for punch

    public float cooldown = 0.5f;

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
        if (cooldown <= 0)
        {
            punchSFX.Play(); //plays punch sfx

            rightPunch.GetComponent<Animator>().Play("RightPunch"); //activates right punch
            leftPunch.GetComponent<Animator>().Play("LeftPunch"); //activates left punch

            cooldown = 0.5f;
        }
    }
}

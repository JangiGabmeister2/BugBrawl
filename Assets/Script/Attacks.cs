using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField] private Animator rightPunch;
    [SerializeField] private Animator leftPunch;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rightPunch.GetComponent<Animator>().Play("RightPunch");  
            leftPunch.GetComponent<Animator>().Play("LeftPunch");  
        }
    }
}

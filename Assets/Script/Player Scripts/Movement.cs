using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed;

    BugAI bug;

    Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
        
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //GetAxis slides player after movement input, GetAxisRaw prevents sliding
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(xAxis, yAxis, 0);

        move.Normalize();
        move *= playerSpeed;
        
        transform.position += move;

        //Atan2 is the angle between the x axis and a 2D vector starting at zero and terminating at (x,y)
        float angle = Mathf.Atan2(yAxis, xAxis) * Mathf.Rad2Deg;

        //prevents player from resetting to starting facing direction after moving
        if (yAxis != 0 || xAxis != 0)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bug")
        {
            Debug.Log("Bug is in punching reach!");

            if (Input.GetKey(KeyCode.Space))
            {
                bug.RemoveBug();
                bug.deathAnimator.GetComponent<Animator>().SetTrigger(bug.deathAnimation.ToString());
            }
        }
    }
}

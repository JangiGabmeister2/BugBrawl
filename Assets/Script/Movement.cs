using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed;
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

        //prevents player from resetting to starting facing direction after inputs
        if (yAxis != 0 || xAxis != 0)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

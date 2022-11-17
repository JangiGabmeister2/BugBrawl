using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed;

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
        if (MenuHandler.menuHandlerInstance.gameState == GameStates.Game)
        {
            //GetAxis slides player after movement input, GetAxisRaw prevents sliding
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");
            Vector3 move = new Vector3(xAxis, yAxis, 0);

            move.Normalize();
            move *= playerSpeed;

            transform.position += move;

            transform.Translate(move, Space.World);

            if (move != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, move);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, playerSpeed * 500);
            }
        }
    }
}

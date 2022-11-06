using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAI : MonoBehaviour
{
    public BugSpawner bugSpawner;
    public GameObject gameArea;

    public Transform player;

    public float speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        /** Move this bug forward per frame, if it gets too far from the game area, destroy it **/

        transform.position += transform.up * (Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, gameArea.transform.position);
        if (distance > bugSpawner.deathCircleRadius)
        {
            RemoveShip();
        }

        if (player.transform.position == transform.position && Input.GetKeyDown(KeyCode.Space))
        {
                GetComponent<Animator>().Play("EnemyPunched");
            RemoveShip();
        }
    }

    void RemoveShip()
    {
        /** Update the total bug count and then destroy this individual bug. **/

        Destroy(gameObject);
        bugSpawner.bugCount -= 1;
    }
}
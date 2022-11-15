using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAI : MonoBehaviour
{
    public BugSpawner bugSpawner;
    public GameObject gameArea;

    public float speed;

    private void Start()
    {

    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (MenuHandler.menuHandlerInstance.gameState == GameStates.Game)
        {
            transform.position += transform.up * (Time.deltaTime * speed);

            float distance = Vector3.Distance(transform.position, gameArea.transform.position);
            if (distance > bugSpawner.deathRadius)
            {
                RemoveBug();
            }
        }
        else
        {
            RemoveBug();
        }
    }

    public void RemoveBug()
    {
        Destroy(gameObject);
        bugSpawner.bugCount -= 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Richard")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.rotation = collision.gameObject.transform.rotation;

                speed = 1000; //sets speed to fly off

                //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, collision.gameObject.transform.rotation.z - 90)); //changes rotation to player's rotation
                transform.localScale = Vector3.one * 10f; //changes size
            }
        }
    }
}
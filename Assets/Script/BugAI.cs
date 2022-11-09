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
        transform.position += transform.up * (Time.deltaTime * speed);

        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-45f,45f));

        float distance = Vector3.Distance(transform.position, gameArea.transform.position);
        if (distance > bugSpawner.deathCircleRadius)
        {
            RemoveBug();
        }
    }

    void RemoveBug()
    {
        Destroy(gameObject);
        bugSpawner.bugCount -= 1;
    }
}
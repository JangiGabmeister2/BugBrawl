using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAI : MonoBehaviour
{
    public BugSpawner bugSpawner;
    public GameObject gameArea;

    public Animator deathAnimator;
    public AnimationClip deathAnimation;

    public float speed;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.up * (Time.deltaTime * speed); //moves the bug forward at a certain speed

        float distance = Vector3.Distance(transform.position, gameArea.transform.position); //returns the difference in distance between the bug's position and game area's position
        if (distance > bugSpawner.deathCircleRadius) //checks if above distance is larger than death circl radius
        {
            RemoveBug();
        }
    }

    public void RemoveBug()
    {
        Destroy(gameObject); //destroys the bug
        bugSpawner.bugCount -= 1; //decreases the number of bugs currently existing by 1
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BugAI : MonoBehaviour
{
    public BugSpawner bugSpawner;
    public Timer timerScore;

    public GameObject gameArea;
    public AudioSource screamSFX;

    Rigidbody2D rb;

    public float speed;

    private float lifeTime = 30f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (MenuHandler.menuHandlerInstance.gameState == GameStates.Game)
        {
            lifeTime -= Time.deltaTime;

            //transform.position += transform.up * (Time.deltaTime * speed);
            Vector3 forwardVector = transform.up;
            rb.MovePosition(rb.position + new Vector2(forwardVector.x, forwardVector.y) * speed /10f);

            float distance = Vector3.Distance(transform.position, gameArea.transform.position);
            if (distance > bugSpawner.deathRadius || lifeTime == 0f)
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

    public virtual void OnTriggerStay2D(Collider2D collision) { }
}
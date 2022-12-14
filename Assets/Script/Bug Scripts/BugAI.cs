using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BugAI : MonoBehaviour
{
    public BugSpawner bugSpawner;
    public Timer timerScore;

    public GameObject gameArea;
    public AudioSource screamSFX;

    public GameObject pointIndicator;
    public Text pointIndicatorText;

    Rigidbody2D rb;

    public float speed;

    float lifeTime = 15f;
    protected bool alreadyCalled = false;

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
            rb.MovePosition(rb.position + new Vector2(forwardVector.x, forwardVector.y) * speed / 10f);

            float distance = Vector3.Distance(transform.position, gameArea.transform.position);
            if (distance > bugSpawner.deathRadius)
            {
                RemoveBug();
            }
            if (lifeTime <= 0f)
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

    public void SpawnPointIndicator(string text)
    {
        pointIndicatorText.text = text;

        if (!alreadyCalled)
        {
            GameObject newGO = Instantiate(pointIndicator, transform.position, Quaternion.identity, gameArea.transform);

            Destroy(newGO, 1f);
        }
    }

    public virtual void OnTriggerStay2D(Collider2D collision) { }
}
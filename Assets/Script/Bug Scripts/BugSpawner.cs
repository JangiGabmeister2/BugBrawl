using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject gameArea; //the area the bugs will spawn around
    public GameObject bugPrefab; //the bugs itself

    public int bugCount = 0; //the number of bugs currently existing
    public int bugLimit = 150; //the limit of how many bugs can exist at one time
    public int bugsPerFrame = 1; //the rate at which a bug is created per game frame

    public float spawnCircleRadius = 20.0f; //the radius around the center of the screen where bugs will spawn
    public float deathCircleRadius = 30.0f; //the radius where bugs will be deleted if they cross it

    public Animator punchedAnimation;

    private void Start()
    {

    }

    void Update()
    {
        MaintainPopulation();
    }

    //creates more bugs as they are destroyed while keeping it within the limit
    void MaintainPopulation()
    {
        //checks if bug count is within the limit
        if (bugCount < bugLimit)
        {
            //for every bug created per frame
            for (int i = 0; i < bugsPerFrame; i++)
            {
                Vector3 position = GetRandomPosition(); //randomises spawn position
                BugAI bug_script = SpawnBug(position); //spawns a bug at that position
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position = Random.insideUnitCircle;

        position = position.normalized;

        position *= spawnCircleRadius;
        position += gameArea.transform.position;

        return position;
    }

    BugAI SpawnBug(Vector3 position)
    {
        bugCount += 1;
        GameObject new_bug = Instantiate(bugPrefab, position, Quaternion.FromToRotation(Vector3.up, gameArea.transform.position - position), gameObject.transform);

        BugAI bug_script = new_bug.GetComponent<BugAI>();   
        bug_script.bugSpawner = this;
        bug_script.gameArea = gameArea;
        bug_script.speed = Random.Range(5f, 20f);

        return bug_script;
    }
}
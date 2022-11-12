using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject gameArea; //the area the bugs will spawn around
    public GameObject[] bugPrefab; //the bugs itself
    public Transform player;

    public int bugCount = 0; //the number of bugs currently existing
    public int bugLimit; //the limit of how many bugs can exist at one time
    public int bugsPerFrame ; //the rate at which a bug is created per game frame

    public float spawnCircleRadius; //the radius around the center of the screen where bugs will spawn
    public float deathCircleRadius; //the radius where bugs will be deleted if they cross it

    [SerializeField] Animator punchedAnimator;
    [SerializeField] AnimationClip punchedAnimClip;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBug), 1f, 1f);
    }

    void Update()
    {

    }

    //creates more bugs as they are destroyed while keeping it within the limit
    void SpawnBug()
    {
        //checks if bug count is within the limit
        if (bugCount < bugLimit)
        {
            for (int i = 0; i < bugsPerFrame; i++)
            {
                Vector3 position = GetRandomPosition(); //randomises spawn position
                BugAI bug_script = SpawnBug(position); //spawns a bug at that position
                bug_script.transform.rotation *= Quaternion.Euler(0f, 0f, Random.Range(-22.5f, 22.5f)); //randomises rotation to create illusion of bugs mindlessly wandering the screen
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position = Random.insideUnitCircle.normalized;

        position *= spawnCircleRadius;
        position += gameArea.transform.position;

        return position;
    }

    BugAI SpawnBug(Vector3 position)
    {
        bugCount += 1;
        GameObject new_bug = Instantiate(bugPrefab[Random.Range(0, bugPrefab.Length)], position, Quaternion.FromToRotation(Vector3.up, gameArea.transform.position - position), gameObject.transform);

        BugAI bug_script = new_bug.GetComponent<BugAI>();
        bug_script.bugSpawner = this;
        bug_script.gameArea = gameArea;
        bug_script.speed = Random.Range(5f, 20f);
        bug_script.deathAnimator = punchedAnimator;
        bug_script.deathAnimation = punchedAnimClip;

        return bug_script;
    }
}
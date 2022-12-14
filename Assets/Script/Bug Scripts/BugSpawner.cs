using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugSpawner : MonoBehaviour
{
    public GameObject gameArea; //the area the bugs will spawn around
    public GameObject[] bugPrefab; //the bug prefab to be spawned into the game

    public GameObject pointIndicatorPrefab;
    public Text pointIndicatorText;

    public Timer scoreTimer;

    public int bugCount = 0; //the number of bugs currently existing
    public int bugLimit; //the limit of how many bugs can exist at one time
    public int bugsPerFrame; //the rate at which a bug is created per game frame

    public float spawnRadius; //the radius around the center of the screen where bugs will spawn
    public float deathRadius; //the radius where bugs will be deleted if they cross it

    private void Start()
    {
        InvokeRepeating(nameof(MaintainPopulation), 1f, 1f);
    }

    //creates more bugs as they are destroyed while keeping it within the limit
    void MaintainPopulation()
    {
        if (MenuHandler.menuHandlerInstance.gameState == GameStates.Game)
        {
            //checks if bug count is within the limit
            if (bugCount < bugLimit)
            {
                //for every bug created per frame
                for (int i = 0; i < bugsPerFrame; i++)
                {
                    Vector3 position = GetRandomPosition(); //randomises spawn position
                    BugAI bug_script = SpawnBug(position); //spawns a bug at that position
                    bug_script.transform.Rotate(Vector3.forward * Random.Range(-22.5f, 22.5f)); //randomises bug rotation to create illusion of bugs mindlessly crawling over screen
                }
            }
        }
    }

    //returns a random position around a circle around the game area
    Vector3 GetRandomPosition()
    {
        Vector3 position = Random.insideUnitCircle.normalized; //returns the positions around the circle and not within it

        position *= spawnRadius; //sets the radius of the circle
        position += gameArea.transform.position; //sets the game area center as the center of the circle

        return position;
    }

    BugAI SpawnBug(Vector3 position)
    {
        bugCount += 1;

        int i = Random.Range(0, 200);
        if (i >= 2)
        {
            i = Random.Range(2, 6);
        }

        GameObject new_bug = Instantiate(bugPrefab[i], position, Quaternion.FromToRotation(Vector3.up, gameArea.transform.position - position), gameObject.transform);

        BugAI bug_script = new_bug.GetComponent<BugAI>();
        bug_script.bugSpawner = this;
        bug_script.gameArea = gameArea;
        bug_script.speed = Random.Range(5f, 20f);
        bug_script.timerScore = scoreTimer;
        bug_script.pointIndicator = pointIndicatorPrefab;
        bug_script.pointIndicatorText = pointIndicatorText;

        return bug_script;
    }
}
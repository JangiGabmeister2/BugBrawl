using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.transform.rotation;
    }
}

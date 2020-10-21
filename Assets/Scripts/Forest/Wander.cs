using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public Transform HumanPlayer;
    int MoveSpeed = 3;
    int MaxDistance = 20;
    int MinDistance = 1;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(HumanPlayer);

        if (Vector3.Distance(transform.position, HumanPlayer.position) >= MinDistance)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, HumanPlayer.position) <= MaxDistance);
        }
    }
}

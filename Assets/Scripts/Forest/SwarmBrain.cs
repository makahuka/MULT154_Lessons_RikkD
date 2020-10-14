using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBrain : MonoBehaviour
{
    //While it has the hive, patrol around the hive
    // When no hive, pursue the player
    private bool hasHive = true;
    private Patrolling patrol; // This and this for collecting coin and accessing the sweets spot
    private Bot bot;

    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<Patrolling>();
        bot = GetComponent<Bot>();
        HivePickUp.HivePickedUp += HiveTaken;
    }

    void HiveTaken()
    {
        hasHive = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(hasHive)
        {
            patrol.PatrolWaypoints(); // This and this for collecting coin and accessing the sweets spot
        }
        else
        {
            bot.Pursue();
        }
    }
}

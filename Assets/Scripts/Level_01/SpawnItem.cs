using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject SpawnObjs;
    public GameObject TicketObjs;
    //public int coins;
    bool coins;

    private MovePawn coin;
    private Vector3 coinPos;
    private bool coinUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<MovePawn>();
        MovePawn.UseCoin += CoinReady;
    }

    void CoinReady(Vector3 pos)
    {
        coinPos = pos;
        coinUsed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //bool coins = true;

        //var coins = true;

        if (coinUsed == false) // if player has coin spawn a treat or a golden ticket
        {
            Debug.Log("No Sweets:(");
        }
        else if(coinUsed == true)
        {

            if (Random.value < 0.8f)
            {
                Instantiate(SpawnObjs, transform.position, transform.rotation);
                Debug.Log("You got sweets:)");
            }
            else
            {
                Instantiate(TicketObjs, transform.position, transform.rotation);
                Debug.Log("You got a golden ticket!");
            }
            Debug.Log("Collect a treat!");
        }
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Reset");
    }
}
/*  private bool hasHive = true;
    private Patrolling patrol; // This and this for collecting coin and accessing the sweets spot
    void Update()
    {
        if(hasHive)
        {
            patrol.PatrolWaypoints(); // This and this for collecting coin and accessing the sweets spot
        }
    }*/
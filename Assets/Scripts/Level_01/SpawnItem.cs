using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    public GameObject SpawnObjs;
    public GameObject TicketObjs;
    public Text gotTicket;

    private MovePawn coin;
    private Vector3 coinPos;
    private bool coinUsed = false;

    /// <summary>
    /// The positions. these are the positons of your spawn points
    public GameObject[] positions;

    //public GameObject MyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<MovePawn>();
        MovePawn.UseCoin += CoinReady;
        StartCoroutine(TextCoroutine());
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

        if (coinUsed == false) // if player has coin spawn a treat or a golden ticket
        {
            Debug.Log("No Sweets:(");
        }
        else if(coinUsed == true) //other.gameObject.tag == "CandyBar" && coins >= 1/*other.gameObject.tag == "CandyBar"*/) // subtracts coin 
        {
            if (Random.value < 0.8f) // Use < 0.8f for game, use for testing < 0.1f
            {
                Instantiate(SpawnObjs, transform.position, transform.rotation);
                Debug.Log("You got sweets:)");

                coinUsed = false;
            }
            else
            {
                Instantiate(TicketObjs, transform.position, transform.rotation);
                Debug.Log("You got a golden ticket!");

                // Cancel all Invoke calls
                if (TicketObjs == true) // Ticket spawned, shops stop spawning
                gotTicket.gameObject.SetActive(true);
                CancelInvoke();
                coinUsed = false;
            }
            Debug.Log("Collect a treat!");

            // if coin is used, reset use coin, this isn't working very well
            /*if (coinUsed == true)
            {
                coinUsed = false;
            }*/
        }
    }
    IEnumerator TextCoroutine()
    {
        if (TicketObjs == true)
        //gotTicket.gameObject.SetActive(true);
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    private void Destroy(GameObject[] positions)
    {
        throw new System.NotImplementedException();
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
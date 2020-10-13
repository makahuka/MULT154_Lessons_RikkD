using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject SpawnObjs;
    public GameObject TicketObjs;
    //public int coins;
    bool coins;
    // Start is called before the first frame update
    void Start()
    {
        /*GameObject MovePawn = GameObject.Find("Pawn");
        MovePawn movePawnScript = MovePawn.GetComponent<MovePawn>();
        movePawnScript.coins -= 0;*/
        //var coins = true;
        // Instantiate(SpawnObjs, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    [SerializeField] private Vector3 dPos;
    private bool _open;  

    public void Deactivate()
    public void Activate() {
    if (!_open) {
    Vector3 pos = transform.position + dPos;
    transform.position = pos;
    _open = true;
    }
   }
   public void Deactivate() {
    if (_open) {
    Vector3 pos = transform.position - dPos;
    transform.position = pos;
    _open = false;
    }
   }*/

    private void OnTriggerEnter(Collider other)
    {
        //bool coins = true;

        //var coins = true;

        if (coins == false) // if player has coin spawn a treat or a golden ticket
        {
            Debug.Log("No Sweets:(");
        }
        else if(coins == true)
        {
            Debug.Log("Collect a treat!");
        }

        /*if (Random.value < 0.8f)
        {
            Instantiate(SpawnObjs, transform.position, transform.rotation);
            Debug.Log("You got sweets:)");
        }
        else
        {
                Instantiate(TicketObjs, transform.position, transform.rotation);
                Debug.Log("You got a golden ticket!");
        }*/
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Reset");
    }
}

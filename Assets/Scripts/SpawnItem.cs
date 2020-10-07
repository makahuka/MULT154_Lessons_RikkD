using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject SpawnObjs;
    public GameObject TicketObjs;

    // Start is called before the first frame update
    /*void Start()
    {
        Instantiate(SpawnObjs, transform.position, transform.rotation);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Random.value < 0.8f)
        {
            Instantiate(SpawnObjs, transform.position, transform.rotation);
            Debug.Log("You got sweets:)");
        }
        else
        {
                Instantiate(TicketObjs, transform.position, transform.rotation);
                Debug.Log("You got a golden ticket!");
        }
    }
}

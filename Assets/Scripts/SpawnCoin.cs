using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject CoinSpawner;

    //public GameObject[] objCoin;

    Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(SpawnObjs, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(Random.value < 0.5f)
        {
            Instantiate(CoinSpawner, transform.position, transform.rotation);
            Debug.Log("You got a coin!");
        }
        else
        {
            Debug.Log("No Coin:(");
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        Debug.Log("Still in the object");
    }*/

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("Reset");
    }
}
/*if (Random.value < 0.5f) {
     // do one thing
 }
 else {
     // do the other thing
 }*/
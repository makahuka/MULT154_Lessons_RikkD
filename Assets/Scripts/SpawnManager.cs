using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : NetworkBehaviour
{
    public GameObject[] lilyPadObjs = null;

    // Start is called before the first frame update
    public override void OnStartServer()
    {
        InvokeRepeating("SpawnLilyPad", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLilyPad()
    {
        foreach (GameObject lilyPad in lilyPadObjs)
        {
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));//Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            GameObject tempLilyPad = Instantiate(lilyPad/*[Random.Range(0, lilyPad.Length)], transform.position, Quaternion.identity*/); //(lilyPad[Random.Range(0, Items.Length)], transform.position, Quaternion.identity);
            NetworkServer.Spawn(tempLilyPad);
        }
    }
}

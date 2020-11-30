using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private GameObject[] stores;

    public GameObject TicketObjs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (TicketObjs == true)
        {
            if(other.gameObject.tag == "Pawn");
            Application.LoadLevel("ChocolateRiver");
        }
    }

    /*void OnTriggerExit(Collider other) 
    {
        foreach (GameObject target in stores) 
        {
            target.SendMessage("Deactivate");
        }
    }*/
}


/*
public class DeviceTrigger : MonoBehaviour {
 [SerializeField] private GameObject[] targets;
 void OnTriggerEnter(Collider other) {
 foreach (GameObject target in targets) {
 target.SendMessage("Activate");
 }
 }
 void OnTriggerExit(Collider other) {
 foreach (GameObject target in targets) {
 target.SendMessage("Deactivate");
 }
 }
} 
*/
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CollectObjects : MonoBehaviour //NetworkBehaviour
{
    private Dictionary<Item.VegetableType, int> ItemInventory = new Dictionary<Item.VegetableType, int>();

    public delegate void CollectItem(Item.VegetableType item);
    public static event CollectItem ItemCollected;

    Collider itemCollider = null;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Item.VegetableType item in System.Enum.GetValues(typeof(Item.VegetableType)))
        {
            ItemInventory.Add(item, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/

        if (itemCollider && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar and item collected");
            Item item = itemCollider.gameObject.GetComponent<Item>();
            AddToInventory(item);
            PrintInventory();
            //Debug.Log("Got Coin!");

            //CmdItemCollected(item.typeOfVeggie);
        }
    }

    /*[Command]
    void CmdItemCollected(Item.VegetableType itemType)
    {
        Debug.Log("CommandItemCollected: " + itemType);
        RpcItemCollected(itemType);
    }

    [ClientRpc]
    void RpcItemCollected(Item.VegetableType itemType)
    {
        ItemCollected?.Invoke(itemType);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/

        if (other.CompareTag("Item"))
        {
            itemCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/

        if (other.CompareTag("Item"))
        {
            itemCollider = null;

            //Destroy(gameObject);
        }
    }

    private void AddToInventory(Item item)
    {
        ItemInventory[item.typeOfVeggie]++;
    }

    private void PrintInventory()
    {
        string output = "";

        foreach (KeyValuePair<Item.VegetableType, int> kvp in ItemInventory)
        {
            output += string.Format("{0}: {1} ", kvp.Key, kvp.Value);
        }

        Debug.Log(output);
    }
}
/*
 [SerializeField] private string itemName;
 void OnTriggerEnter(Collider other) {
 Debug.Log("Item collected: " + itemName);
 Destroy(this.gameObject);*/
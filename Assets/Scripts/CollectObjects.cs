using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CollectObjects : MonoBehaviour //NetworkBehaviour
{
    private Dictionary<Items.ObjectType, int> ItemInventory = new Dictionary<Items.ObjectType, int>();

    public delegate void CollectItem(Items.ObjectType item);
    public static event CollectItem ItemCollected;

    Collider itemCollider = null;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Items.ObjectType item in System.Enum.GetValues(typeof(Items.ObjectType)))
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

        if (itemCollider && Input.GetKeyDown(KeyCode.Space)) // (_items.ContainsKey(name) && equippedItem != name)
        {
            Debug.Log("Space bar and item collected");
            Items item = itemCollider.gameObject.GetComponent<Items>();
            AddToInventory(item);
            PrintInventory();

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

    private void AddToInventory(Items item)
    {
        ItemInventory[item.typeOfObject]++;
    }

    private void PrintInventory()
    {
        string output = "";

        foreach (KeyValuePair<Items.ObjectType, int> kvp in ItemInventory)
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
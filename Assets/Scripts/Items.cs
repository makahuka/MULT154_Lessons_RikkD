using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private string itemName;

    public enum ObjectType
    { 
        COIN,
        CANDYBAR
    }

    private void Update()
    {
        Debug.Log("Item collected: " + itemName);
        //if (Input.GetKey(KeyCode.Space))
        /*{
            //Debug.Log("Item collected: " + itemName);
            //Destroy(this.gameObject);
        }*/
    }

    public ObjectType typeOfObject;
}

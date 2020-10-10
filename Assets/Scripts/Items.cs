using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private string itemName;

    public enum VegetableType
    { 
        COIN,
        CANDYBAR
    }

    private void Update()
    {
        Debug.Log("Item collected: " + itemName);
    }

    public VegetableType typeOfVeggie;
}

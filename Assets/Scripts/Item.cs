using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;

    public enum VegetableType
    {
        BEET,
        CARROT,
        RADISH
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Item collected: " + itemName);
        }
    }

    public VegetableType typeOfVeggie;
}

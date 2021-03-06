﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePawn : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Vector3 direction = Vector3.zero;
    public float speed = 10.0f;
    //public GameObject[] spawnPoints = null;

    public Text CoinCount;
    public int coins = 0;

    public Text SweetsCount;
    private int sweets = 0;

    public delegate void CoinUse(Vector3 pos);
    public static event CoinUse UseCoin;

    public GameObject coinUsed;

    private Animator anim;
    private float translation;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        //spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        // need to try this code-->bool UseCoin = true;  
    }

    private void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        direction = new Vector3(horMove, 0, verMove);


        anim.SetFloat("speed", translation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbPlayer.AddForce(direction * speed, ForceMode.Force);

        if (transform.position.z > -16)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -16);
        }
        else if (transform.position.z < -40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        }
        else if (transform.position.x > 60)
        {
            transform.position = new Vector3(60, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -60)
        {
            transform.position = new Vector3(-60, transform.position.y, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            UseCoin?.Invoke(transform.position/* + (transform.forward * 5)*/);

            coins = 1;
            CoinCount.text = "Coin: " + coins;

            if (other.gameObject.tag == "Coin" && coins == 1)
            {
                CancelInvoke();
            }
        }

        if (other.gameObject.tag == "CandyBar" && coins >= 1/*other.gameObject.tag == "CandyBar"*/) // subtracts coin 
        {
            other.gameObject.SetActive(false);

            sweets += 1;
            SweetsCount.text = "Sweets: " + sweets;

            coins -= 1;
            CoinCount.text = "Coin: " + coins;
        }

        if (other.gameObject.tag == "Ticket")
        {
            other.gameObject.SetActive(false);

            //coins -= 1;
            CoinCount.text = "Coin: " + coins;
        }
    }

    /*private void OnTriggerExit(Collider col)
    {
        Debug.Log("Reset");
    }*/
}

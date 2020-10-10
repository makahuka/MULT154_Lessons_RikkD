using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/

        rbPlayer = GetComponent<Rigidbody>();
        //spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

    }

    private void Update()
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/

        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        direction = new Vector3(horMove, 0, verMove);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/

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

    /*private void Respawn()
    {
        int index = 0;
        while (Physics.CheckBox(spawnPoints[index].transform.position, new Vector3(1.5f, 1.5f, 1.5f)))
        {
            index++;
        }
        rbPlayer.MovePosition(spawnPoints[index].transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CandyBar")
        {
            other.gameObject.SetActive(false);

            sweets += 1;
            SweetsCount.text = "Sweets: " + sweets;
        }

        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);

            coins += 1;
            CoinCount.text = "Coin: " + coins;
        }
    }
}

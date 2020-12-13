using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public abstract class PlayerState
{
    protected NetworkBehaviour thisObject;
    protected string stateName;
    protected GameObject player;

    protected PlayerState(NetworkBehaviour thisObj)
    {
        thisObject = thisObj;
        player = thisObject.gameObject;
    }

    public abstract void Start();

    public abstract void Update();

    public abstract void FixedUpdate();

    public abstract void OnTriggerEnter(Collider other);

    public abstract void OnTriggerExit(Collider other);

}

public class RiverState : PlayerState
{
    private Rigidbody rbPlayer;
    private Vector3 direction = Vector3.zero;
    public float speed = 20.0f;
    public GameObject[] spawnPoints = null;

    public RiverState(NetworkBehaviour thisObj) : base(thisObj)
    {
        stateName = "RiverLevel";
    }

    // Start is called before the first frame update
    public override void Start()
    {

        rbPlayer = player.GetComponent<Rigidbody>();
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

    }

    public override void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        direction = new Vector3(horMove, 0, verMove);
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(player.transform.position, direction * 10);
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(player.transform.position, rbPlayer.velocity * 5);
        // Draw a blue cube at the transform position
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(player.transform.position, new Vector3(5, 5, 5));
    }*/

    // Update is called once per frame
    public override void FixedUpdate()
    {
        rbPlayer.AddForce(direction * speed, ForceMode.Force);

        if (player.transform.position.z > 40)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 40);
        }
        else if (player.transform.position.z < -40)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -40);
        }
    }

    private void Respawn()
    {
        int index = 0;
        while (Physics.CheckBox(spawnPoints[index].transform.position, new Vector3(1.5f, 1.5f, 1.5f)))
        {
            index++;
        }
        rbPlayer.MovePosition(spawnPoints[index].transform.position);
        rbPlayer.velocity = Vector3.zero;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            NetworkManager network =
                GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
            networkManager.ServerChangeScene("ForestLevel");
        }
    }
    
    public override void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }
    }
}

/*public class ForestState : PlayerState
{
    public ForestState(NetworkBehaviour thisObj) : base(thisObj)
    {
        stateName = "ForestLevel";
    }
}*/

public class PlayerContext : NetworkBehaviour
{
    PlayerState currentState;
    RiverState riverState;
    //ForestState forestState;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer) return;

        if(SceneManager.GetActiveScene().name == "RiverLevel")
        {
            currentState = new RiverState(this);
        }

        currentState.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        currentState.Update();
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        currentState.Update();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer) return;

        currentState.OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer) return;

        currentState.OnTriggerExit(other);
    }
}

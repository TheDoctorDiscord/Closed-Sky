using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaivior : MonoBehaviour
{
    public GameObject[] Waypoints;
    public float Speed;

    public int curWaypoint;
    public bool Patrol = true;
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity;
    public int attackdamage = 1;
    GameObject PlayerObject;
    PlayerBehaivior playerHealth;



    void Awake()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        curWaypoint = Random.Range(0, Waypoints.Length);
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = PlayerObject.GetComponent<PlayerBehaivior>();
        
    }
    private void OnDestroy()
    {
        
        EnemySpawner.mob2countdown -= 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(attackdamage);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        

        if (curWaypoint < Waypoints.Length)
        {
            Target = Waypoints[curWaypoint].transform.position;
            MoveDirection = Target - transform.position;
            Velocity = GetComponent<Rigidbody>().velocity;

            if (MoveDirection.magnitude < 1 && Patrol)
            {
                curWaypoint = Random.Range(1,Waypoints.Length);
            }
            else
            {
                Velocity = MoveDirection.normalized * Speed;
            }
        }
        else
        {
            if(Patrol)
            {
                curWaypoint = 0;
            }
            else
            {
                Velocity = Vector3.zero;
            }
        }
        GetComponent<Rigidbody>().velocity = Velocity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaiviorHeli : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnDestroy()
    {
        EnemySpawner.mob3countdown -= 1;
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
    float timer = 1f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
        Target = Waypoints[curWaypoint].transform.position;
        MoveDirection = Target - transform.position;
        Velocity = GetComponent<Rigidbody>().velocity;
        Velocity = MoveDirection.normalized * Speed;
        GetComponent<Rigidbody>().velocity = Velocity;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
}

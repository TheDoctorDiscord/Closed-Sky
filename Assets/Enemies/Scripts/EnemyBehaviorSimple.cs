using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorSimple : MonoBehaviour
{
    
    public float Speed;



    
    
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity;
    public int attackdamage = 1;
    GameObject PlayerObject;
    PlayerBehaivior playerHealth;



    void Awake()
    {
        Target = new Vector3(transform.position.x,0,transform.position.z-30);
        MoveDirection = Target - transform.position;
        Velocity = GetComponent<Rigidbody>().velocity;
        
        Velocity = MoveDirection.normalized * Speed;
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = PlayerObject.GetComponent<PlayerBehaivior>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8f);
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
        GetComponent<Rigidbody>().velocity = Velocity;
    }
}

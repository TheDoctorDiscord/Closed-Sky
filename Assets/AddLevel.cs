using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLevel : MonoBehaviour
{
    public int DeathTime;
    private readonly int speed = 5;
    GameObject PlayerObject;
    PlayerBehaivior playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, DeathTime);
    }

    private void Awake()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = PlayerObject.GetComponent<PlayerBehaivior>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.Lvlup();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

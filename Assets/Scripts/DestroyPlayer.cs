using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyPlayer : MonoBehaviour
{
    public int attackdamage = 1;
    GameObject PlayerObject;
    PlayerBehaivior playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            playerHealth.TakeDamage(attackdamage);
            Destroy(gameObject);
        }
    }
}

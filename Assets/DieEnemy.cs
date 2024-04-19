using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour
{
    public GameObject ScoreBox;
    public GameObject LvlBox;
    public int HP;
    private int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = HP;
        
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0 && Mathf.Abs(currentHealth) < amount)
        {
            Destroy(gameObject);
            
            Instantiate(ScoreBox, transform.position, transform.rotation);
            Instantiate(LvlBox, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

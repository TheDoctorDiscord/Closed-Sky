using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Mobs;
    public GameObject Boss;
    public GameObject Player;
    public int id;
    public DeathMenu theDeathScreen;
    public Camera BG;
    float maxSpawnRateInSeconds = 3f;
    float timer1 = 21f;
    float timer2 = 21f;
    public static int moblimit = 1;
    
    public static int mob2countdown = 3;
    public static int mob3countdown = 2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnMob), maxSpawnRateInSeconds);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer1 -= Time.deltaTime;
        
        if (timer1 < 0 && id == 0)
        {
            id +=1;
            CancelInvoke(nameof(SpawnMob));
            moblimit = 3;
        }
        if (id == 1 && moblimit > 0)
        {
            SpawnMob();
            moblimit = 0;
        }
        if (id == 1 && mob2countdown == 0)
        {
          
            moblimit = 2;
            id++;
        }
        if (id == 2 && moblimit > 0 )
        {
            SpawnMob();
            moblimit = 0;
            
        }
        if (id == 2 && mob3countdown == 0)
        {
            id++;
            moblimit = 1;
            timer2 = 12f;
        }
        if (id == 3 && timer2 >= 0)
        {
            Player.GetComponent<PlayerBehaivior>().fire = false;
            SpawnMob();
            moblimit = 0;
        }
        
    }
    public void SpawnMob()
    {
        if(id == 0)
        {
            moblimit++;
            
            Vector3 min = new Vector3(-3, 0, 21);

            Vector3 max = new Vector3(3, 0, 21);

            GameObject anEnemy = (GameObject)Instantiate(Mobs[id]);
            anEnemy.transform.position = new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
            Invoke(nameof(SpawnMob), maxSpawnRateInSeconds);


        }
        else if (id == 1)
        {
            moblimit++;
            Vector3 min = new Vector3(-3, 0, 21);

            Vector3 max = new Vector3(3, 0, 21);

            GameObject anEnemy = (GameObject)Instantiate(Mobs[id]);
            anEnemy.transform.position = new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
            anEnemy = (GameObject)Instantiate(Mobs[id]);
            anEnemy.transform.position = new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
            anEnemy = (GameObject)Instantiate(Mobs[id]);
            anEnemy.transform.position = new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
            
        }
        else if (id == 2)
        {
            moblimit++;
            Vector3 min = new Vector3(-3, 0, 21);

            Vector3 max = new Vector3(3, 0, 21);
            GameObject anEnemy = (GameObject)Instantiate(Mobs[id]);
            anEnemy.transform.position = new Vector3(min.x, max.y, max.z);
            anEnemy = (GameObject)Instantiate(Mobs[id]);
            anEnemy.transform.position = new Vector3(max.x, max.y, max.z);
            
        }
        else if (id == 3)
        {
            
            Boss.SetActive(true);
            timer2 -= Time.deltaTime;
            if (timer2 > 0)
            {
                Vector3 Target = new Vector3(0, 0, 15);
                Vector3 MoveDirection = Target - Boss.transform.position;
                Vector3 Velocity = Boss.GetComponent<Rigidbody>().velocity;
                Velocity = MoveDirection.normalized * Boss.GetComponent<EnemyBoss1Behavior>().Speed;
                Boss.GetComponent<Rigidbody>().velocity = Velocity;
            }
            else
            {
                
                Player.GetComponent<PlayerBehaivior>().fire = true;
                Boss.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
            }


        }
    }
}

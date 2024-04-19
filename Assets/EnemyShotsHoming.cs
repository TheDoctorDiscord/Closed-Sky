using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotsHoming : MonoBehaviour
{
    public GameObject Shot;

    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            GameObject playerShip = GameObject.Find("Player");
            if (playerShip != null)
            {
                nextFire = Time.time + fireRate;
                GameObject bullet = (GameObject)Instantiate(Shot);
                bullet.transform.position = transform.position;

                
                Vector3 direction = playerShip.transform.position - bullet.transform.position;
                direction = new Vector3(direction.x, direction.y, direction.z - 1);
                bullet.GetComponent<HomingBullet>().SetDirection(direction);
                
            }

        }
        

        
    }
}

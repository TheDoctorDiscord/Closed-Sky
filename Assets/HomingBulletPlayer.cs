using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletPlayer : MonoBehaviour
{
    public GameObject Shot;

    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FireHomingBullet()
    {
            GameObject enemyShip = GameObject.FindGameObjectWithTag("Enemy");
            if (enemyShip == null)enemyShip = GameObject.FindGameObjectWithTag("Boss");
            if (enemyShip != null)
            {
                
                nextFire = Time.time + fireRate;
                //AudioSource audio = GetComponent<AudioSource>();
                //audio.Play();
                GameObject bullet = (GameObject)Instantiate(Shot);
                bullet.transform.position = transform.position;


                Vector3 direction = enemyShip.transform.position - bullet.transform.position;
                direction = new Vector3(direction.x, direction.y, direction.z - 1);
                bullet.GetComponent<HomingBullet>().SetDirection(direction);
        }
    }
}


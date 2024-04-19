using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShots : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Shot;

    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0;i<36;i++)
            {
            Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
            BulletSpawn.Rotate(new Vector3(0, 10, 0));
            }
        }
    }
}

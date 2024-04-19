using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotsBoss1 : MonoBehaviour
{
    public GameObject Shot;
    public bool active = false;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
    int gunrotation=1;
    int shotcount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Time.time > nextFire && shotcount <= 26)
            {
                nextFire = Time.time + fireRate;
                shotcount++;
                Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
                BulletSpawn.Rotate(new Vector3(0, 1 * gunrotation, 0));
            }
            else if (shotcount > 26)
            {
                gunrotation = -gunrotation;
                shotcount = 0;
            }

        }
    }
}

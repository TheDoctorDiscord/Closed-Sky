using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotsBoss2 : MonoBehaviour
{
    public GameObject Shot;
    public bool active = false;
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
        if (Time.time > nextFire && active)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < 37; i++)
            {
                Instantiate(Shot, BulletSpawn.position, BulletSpawn.rotation);
                BulletSpawn.Rotate(new Vector3(0, 10, 0));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Our_Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float DeathTime;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, DeathTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

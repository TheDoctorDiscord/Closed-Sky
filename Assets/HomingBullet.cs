using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed;
    public float DeathTime;
    bool isReady;
    Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeathTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            Vector3 position = transform.position;
            position += _direction * speed * Time.deltaTime;

            transform.position = position;
        }
    }
}

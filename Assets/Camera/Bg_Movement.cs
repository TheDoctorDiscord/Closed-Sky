using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Movement : MonoBehaviour{
    
    public Transform bg1;

    public Transform bg2;

    public Transform bg3;

    public Transform bg4;

    public float speed;

    private float size;
    // Start is called before the first frame update
    void Start()
    {
        size = bg1.GetComponent<Transform>().localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + speed);

        if (transform.position.z >= bg1.position.z-20)
        {
            bg1.position = new Vector3(bg1.position.x, bg1.position.y, bg4.position.z + size);
            SwitchBG();
        }
    }

    private void SwitchBG()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = bg3;
        bg3 = bg4;
        bg4 = temp;
    }
}

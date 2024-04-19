using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Health;
    private int HP = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeartDamage(int amount)
    {
        Health[HP-1].SetActive(false);
        HP -= amount;
    }
}

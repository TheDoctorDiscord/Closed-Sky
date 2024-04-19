using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvLManager : MonoBehaviour
{
    public static int lvl;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        text = GetComponent<Text>();
        lvl = 1;
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "LvL:" + lvl;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    Text text;
    void Start()
    {
        
    }
    private void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        text.text =""+ score;
    }
}

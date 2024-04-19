using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public string Thislevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Thislevel);
    }

    public void QuitToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuLevel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

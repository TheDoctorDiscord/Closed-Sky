using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss1Behavior : MonoBehaviour
{
    public float Speed;

    public int HP;
    private int currentHealth;
    public Slider healthSlider;
    
    public GameObject BossHPBar;
    public GameObject theDeathScreen;
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity;
    public AudioSource bgaudio;
    public AudioClip musicnew;
    float timer;
    public GameObject bulletorigin1;
    public GameObject bulletorigin2;

    public void TakeDamage(int amount)
    {
        
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= HP / 2)
        {
            Enable2gun();
        }
        if (currentHealth <= HP / 5)
        {
            Enable3gun();
        }
        if (currentHealth <= 0)
        {
            theDeathScreen.gameObject.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
            bgaudio.Stop();
        }
    }

    private void OnEnable()
    {
        BossHPBar.SetActive(true);
        
        Invoke(nameof(Enable1gun), 11f);
        bgaudio.clip = musicnew;
        bgaudio.Play();
        currentHealth = HP;
    }
    private void Enable1gun()
    {
        bulletorigin1.GetComponent<EnemyShotsBoss1>().active = true;
    }
    private void Enable2gun()
    {
        
        bulletorigin2.GetComponent<EnemyShotsBoss2>().active = true;
    }
    private void Enable3gun()
    {
        bulletorigin1.GetComponent<EnemyShotsBoss1>().fireRate = 0.3f;
        bulletorigin2.GetComponent<EnemyShotsBoss2>().fireRate = 0.7f;
    }
    void Awake()
    {
        
        currentHealth = HP;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = HP;
    }

    // Update is called once per frame
    
    void Update()
    {
        timer -= Time.deltaTime;
        
    }
}

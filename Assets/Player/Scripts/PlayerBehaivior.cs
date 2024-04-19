using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float minX, maxX, minZ, maxZ;
}
public class PlayerBehaivior : MonoBehaviour
{
    public float speed;

    public int lvl=1;
    private int chamber = 0;

    GameObject UiObject;
    HealthBar playerHealth;

    public int HP = 3;
    public DeathMenu theDeathScreen;

    public Boundary arena;

    public Camera BG;

    public GameObject[] Shot;

    public Transform BulletSpawn;

    public Transform Bullet2Spawn;

    public Transform Bullet3Spawn;
    AudioSource audio1;
    
    public float fireRate;
    private float nextFire;
    private float nextFire2;
    private float vultimer = 0;
    private bool vulnerability = true;
    public bool fire = true;
    SphereCollider m_collider;
    Animation shimmer;
    void Start()
    {
        if (lvl >=1 && lvl <= 4)
        chamber = lvl - 1;
        else if(lvl > 4)
        {
            chamber = 3;
            fireRate -= 0.05f*(lvl-4);
        }
        LvLManager.lvl = lvl;
    }

    private void Awake()
    {
        m_collider = GetComponent<SphereCollider>();
        shimmer = GetComponent<Animation>();
        UiObject = GameObject.FindGameObjectWithTag("HealthBar");
        playerHealth = UiObject.GetComponent<HealthBar>();
    }
    public void TakeDamage (int amount)
    {
        
        if (vulnerability)
        {   
            HP -= amount;
            vultimer = 3;
            vulnerability = false;
            m_collider.enabled = false;
            shimmer.Play();
            transform.position = new Vector3(0, 0, 2);
            playerHealth.HeartDamage(amount);
            audio1 = GetComponent<AudioSource>();
            
            audio1.Play();
            if (HP <= 0)
            {
                theDeathScreen.gameObject.SetActive(true);
                Destroy(gameObject);
                Time.timeScale = 0;
                var bg = BG.GetComponent<Bg_Movement>();
                bg.speed = 0;
            }
        }
    }

    public void Lvlup()
    {
        if(lvl < 4)
        {
            lvl += 1;
            LvLManager.lvl += 1;
            chamber += 1;
        }
        else if (lvl<10)
        {
            lvl += 1;
            LvLManager.lvl += 1;
            fireRate -= 0.05f;
        }
        else
        {
            ScoreManager.score += 10;
        }
        
    }
    private void FixedUpdate()
    {
        if (vultimer >= 0)
        {
            
            vultimer -= Time.fixedDeltaTime;
            if (vultimer <= 0)
            {
                vulnerability = true;
                m_collider.enabled = true;
                
            } 
        }
        if (Time.time > nextFire && fire == true)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Shot[chamber], BulletSpawn.position, BulletSpawn.rotation);
        }
        if (Time.time > nextFire2 && lvl == 5 && fire == true)
        {
            nextFire2 = Time.time + fireRate * 2;

            HomingBulletPlayer bulletfire = Bullet2Spawn.GetComponent<HomingBulletPlayer>();
            bulletfire.FireHomingBullet();
        }
        if (Time.time > nextFire2 && lvl > 5 && fire == true)
        {
            nextFire2 = Time.time + fireRate * 2;

            HomingBulletPlayer bulletfire = Bullet2Spawn.GetComponent<HomingBulletPlayer>();
            HomingBulletPlayer bulletfire2 = Bullet3Spawn.GetComponent<HomingBulletPlayer>();
            bulletfire.FireHomingBullet();
            bulletfire2.FireHomingBullet();
        }

    }
    private void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, arena.minX, arena.maxX), 0.0f, Mathf.Clamp(rigidbody.position.z, arena.minZ, arena.maxZ));

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector3 direction = (touchPosition - transform.position);
            rigidbody.velocity = new Vector3(direction.x, 0f,direction.z+direction.y) * speed;

            if (touch.phase == TouchPhase.Ended)
                rigidbody.velocity = Vector3.zero;
        }*/
    }
}

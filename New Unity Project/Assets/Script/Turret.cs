using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject m_Player;
    private float speed = 3;
    private float health = 30;
    private Transform firePoint;
    public LayerMask doHit;
    public GameObject bullet;
    public float offset;
    public float fireRate = 0.01f;
    public float damage = 10;
    float timeToFire = 0.01f;
    public int lvl = -1;



    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform;
        m_Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
        if (m_Player == null)
            m_Player = GameObject.FindWithTag("Player");
        if (m_Player != null && fireRate == 0 && m_Player.GetComponent<Player>().level == lvl) 
        {
            Shoot();
        }
        else
        {
            if (m_Player != null && Time.time > timeToFire && m_Player.GetComponent<Player>().level == lvl)
            {
                timeToFire = Time.time + 1/fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 firePointPosition = new Vector2 (firePoint.position.x + offset, firePoint.position.y);
        Vector2 target = new Vector2(m_Player.transform.position.x, m_Player.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, target - firePointPosition, 100, doHit);
        Debug.DrawLine (firePointPosition, (target - firePointPosition) * 100, Color.white);
        Debug.Log(hit.collider);
        if (hit.collider.gameObject.name == "Player")
        {
            GameObject currentBullet = Instantiate(bullet, new Vector3 (firePointPosition.x, firePointPosition.y, 0), Quaternion.identity);
            currentBullet.GetComponent<Rigidbody2D>().AddForce((target - firePointPosition)  * 50);
            Destroy(currentBullet, 2f);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health -= 10;
        }
    }
}

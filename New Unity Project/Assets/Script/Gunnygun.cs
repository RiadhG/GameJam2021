using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunnygun : MonoBehaviour
{
    public float fireRate = 1;
    public float damage = 10;
    public LayerMask onlyHit;
    public GameObject bullet;

    float timeToFire = 0;
    Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("");
        if (firePoint == null)
        {
            Debug.Log("You dun goofed up");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0) 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1/fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
                                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, onlyHit);
        Debug.DrawLine (firePointPosition, (mousePosition - firePointPosition) * 100, Color.red);
        GameObject currentBullet = Instantiate(bullet, new Vector3 (firePointPosition.x, firePointPosition.y, 0), Quaternion.identity);
        currentBullet.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);
        Destroy(currentBullet, 0.5f);
    }
}

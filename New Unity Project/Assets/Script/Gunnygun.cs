using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunnygun : MonoBehaviour
{
    public float fireRate = 0;
    public float damage = 10;
    float timeToFire = 0;
    public LayerMask onlyHit;
    public GameObject bullet;

    Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform;
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
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
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
        Vector2 firePointPosition = new Vector2 (firePoint.position.x + 0.1f, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, onlyHit);
        Debug.DrawLine (firePointPosition, (mousePosition - firePointPosition) * 100, Color.red);
        GameObject currentBullet = Instantiate(bullet, new Vector3 (firePointPosition.x, firePointPosition.y, 0), Quaternion.identity);
        Debug.Log((mousePosition - firePointPosition));
        Vector3 dir = (mousePosition - firePointPosition);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        currentBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        currentBullet.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition)  * 100);
        Destroy(currentBullet, 2f);
    }
}

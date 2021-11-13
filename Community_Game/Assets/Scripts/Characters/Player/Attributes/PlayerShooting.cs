using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private GameObject bulletPrefab;
    private Transform gunPoint;

    private float bulletForce = 20f;

    private float rateShooting = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //bulletPrefab = (GameObject)Resources.Load("Prefabs/Items/Bullet", typeof(GameObject));
        bulletPrefab = GameObject.Find("Bullet");
        gunPoint = GameObject.Find("Gun").transform;

        //Debug.Log("gun pos : " + gunPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (rateShooting <= 0f)
            {
                rateShooting = 0.2f;
                Shoot();
            }

            rateShooting = rateShooting - Time.deltaTime;
        }
    }

    void Shoot()
    {
        //Instantiate(bulletPrefab, gunPoint.position + (gunPoint.up * bulletForce), gunPoint.rotation);

        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>()
        //bullet.GetComponent<Rigidbody2D>().AddForce(gunPoint.right * bulletForce, ForceMode2D.Impulse);
        //rb.AddForce(gunPoint.up, ForceMode2D.Impulse);

        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position + gunPoint.up.normalized, Quaternion.identity);
        if (bullet != null)
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(gunPoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}

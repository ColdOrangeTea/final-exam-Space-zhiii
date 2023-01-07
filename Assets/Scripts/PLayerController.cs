using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    public float moveSpeed;
    public float bulletSpeed;

    Rigidbody2D rb;
    AudioSource au;
    
    public float fireRate;
    float timer;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h,v).normalized;
        
        rb.velocity = dir* moveSpeed;

        timer += Time.deltaTime;
        if(timer > fireRate && Input.GetKey(KeyCode.Space))
        {
            timer = 0;
            Fire();
        }
    }

    void Fire()
    {
        au.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
        Destroy(bullet,10f);
    }

}

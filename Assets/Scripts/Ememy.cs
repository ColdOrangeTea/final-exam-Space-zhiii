using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ememy : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public GameObject exploPrefabs;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<UIManager>().TakeDamage();
            TakeDamage();
        }
        if(collision.gameObject.CompareTag("Border"))
        {
            FindObjectOfType<UIManager>().TakeDamage();
            Destroy(this.gameObject);
        }
    }
    void TakeDamage()
    {
        GameObject explo = Instantiate(exploPrefabs, transform.position, Quaternion.identity);
        FindObjectOfType<UIManager>().GetScore(50);
        Destroy(explo,0.415f);
        Destroy(gameObject);
    }

}

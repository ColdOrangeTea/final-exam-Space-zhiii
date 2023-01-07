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

    // 怪物被子彈打到
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 怪物碰到玩家
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<UIManager>().TakeDamage();
            TakeDamage();
        }

        // 怪物碰到邊界
        if (collision.gameObject.CompareTag("Border"))
        {
            FindObjectOfType<UIManager>().TakeDamage();
            Destroy(this.gameObject);
        }
    }
    void TakeDamage()
    {
        GameObject explo = Instantiate(exploPrefabs, transform.position, Quaternion.identity); // 產生爆炸
        FindObjectOfType<UIManager>().GetScore(1); // 加 1 分數
        Destroy(explo, 0.415f);
        Destroy(gameObject);
    }

}

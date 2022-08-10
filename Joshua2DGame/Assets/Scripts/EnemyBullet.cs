using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float xBounds;
    public float yBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xBounds || transform.position.x < -xBounds ||
            transform.position.y > yBounds || transform.position.y < -yBounds)
        {
            Destroy(gameObject);
        }
        //rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(collision.gameObject); // first kill player bullet
            Destroy(gameObject); // then kill enemy bullet
        }
    }
}

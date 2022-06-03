using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up,
    right,
    down,
    left
}

public class DumbEnemy : MonoBehaviour
{
    public Direction direction; // to know which direction the enemy should go
    public float moveSpeed;

    public float xBounds, yBounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(direction == Direction.up) // the enemy wants to go up
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        //}
        //if (direction == Direction.right) // the enemy wants to go right
        //{
        //    transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        //}
        //if (direction == Direction.down) // the enemy wants to go down
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        //}
        //if (direction == Direction.left) // the enemy wants to go left
        //{
        //    transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        //}
        // when the enemy goes off screen
        if (transform.position.x > xBounds || transform.position.x < -xBounds ||
           transform.position.y > yBounds || transform.position.y < -yBounds)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            // add score
            Destroy(collision.gameObject); // destroy the bullet
            Destroy(gameObject); // destroy the enemy
        }
    }
}

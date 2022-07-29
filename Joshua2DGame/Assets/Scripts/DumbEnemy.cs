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
    public GameObject deathEffect; // to spawn the death particle effect
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // when the enemy goes off screen
        if (transform.position.x > xBounds || transform.position.x < -xBounds ||
           transform.position.y > yBounds || transform.position.y < -yBounds)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            // add score
            Instantiate(deathEffect, transform.position, transform.rotation); // spawn the death effect
            HUDScript.score++; // increase our score
            Destroy(collision.gameObject); // destroy the bullet
            Destroy(gameObject); // destroy the enemy
        }
    }
}

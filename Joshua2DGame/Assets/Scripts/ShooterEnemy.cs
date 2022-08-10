using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    public GameObject deathEffect;
    public float playerDistance; // distance we want it to be from the player
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform; // the player is linked to the player in our scene
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > playerDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // move
        }
        if(distance < playerDistance)
        {
            Vector3 difference = player.position - transform.position; // find the difference between the vectors
            transform.position = Vector3.MoveTowards(transform.position, player.position + difference, Time.deltaTime); // add that to the enemy position
        }
        // look at player
        Vector2 lookdirection = new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y); // the direction we want the ship to look
        float angle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg - 90f; // angle between the player and mouse
        transform.rotation = Quaternion.Euler(0, 0, angle); // apply the angle to our rotation
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            // add score
            Instantiate(deathEffect, transform.position, transform.rotation);
            HUDScript.score++; // increase our score
            Destroy(collision.gameObject); // destroy the bullet
            Destroy(gameObject); // destroy the enemy
        }
    }
}

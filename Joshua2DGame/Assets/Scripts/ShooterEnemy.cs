using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    public GameObject deathEffect;
    public float playerDistance; // distance we want it to be from the player
    public GameObject bullet;
    public float shootTime;
    public Transform raycastPosition; // start pos for the raycast
    public LayerMask layer; // to know about bullets
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform; // the player is linked to the player in our scene
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        // make this >= now so that when distance = playerdistance then we can also do the shooting here
        if (distance >= playerDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // move
            // TO DO: Shooting :)
        }
        if(distance < playerDistance)
        {
            Vector3 difference = player.position - transform.position; // find the difference between the vectors
            // apply this new difference to the enemy position, and to make it smooth also multiply by speed and time
            transform.position = new Vector3(transform.position.x - difference.x * speed * Time.deltaTime, transform.position.y - difference.y * speed * Time.deltaTime);
        }
        // look at player
        Vector2 lookdirection = new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y); // the direction we want the ship to look
        float angle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg - 90f; // angle between the player and mouse
        transform.rotation = Quaternion.Euler(0, 0, angle); // apply the angle to our rotation

        // shooting
        if(shootTime >= 1)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation); // spawn bullet
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 5, ForceMode2D.Impulse); // add force forward
            shootTime = 0;
        }
        shootTime += Time.deltaTime;

        RaycastHit2D[] hit = Physics2D.RaycastAll(raycastPosition.position, lookdirection, Mathf.Infinity, layer);
        //if (hit.collider != hit.collider.GetComponent<Bullet>()) return; // get rid of errors
        //if (hit.collider.GetComponent<Bullet>())
        //{
        //    transform.RotateAround(player.position, Vector3.forward, 500 * Time.deltaTime);
        //}
        foreach(var bullet in hit)
        {
            if(bullet.transform.tag == "Bullet")
            {
                transform.RotateAround(player.position, Vector3.forward, 200 * Time.deltaTime);
            }
        }
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

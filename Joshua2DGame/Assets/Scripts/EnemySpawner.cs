using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform player;
    public float timer; // how often the enemy spawns
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make the spawner look at player
        Vector2 lookdirection = new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y); // the direction we want the ship to look
        float angle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg - 90f; // angle between the player and mouse
        transform.rotation = Quaternion.Euler(0, 0, angle); // apply the angle to our rotation

        if(timer >= 2)
        {
            GameObject newEnemy = Instantiate(Enemy, transform.position, transform.rotation); // spawn enemy
            newEnemy.GetComponent<Rigidbody2D>().AddForce(transform.up * 2, ForceMode2D.Impulse); // shot towards the player
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // slowly increase the timer
    }
}

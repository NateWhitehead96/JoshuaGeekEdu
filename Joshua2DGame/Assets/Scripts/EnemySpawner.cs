using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemy; // make this variable into an array
    public Transform player;
    public float timer; // how often the enemy spawns
    public bool side; // to know if the spawner is on the sides or not. being on the left or right side = true, up or down side = false
    public float spawnTime;
    public float waveTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= spawnTime)
        {
            if(side == true) // if the spawner is a left or right side
            {
                float y = Random.Range(-5f, 5f); // new random y position
                transform.position = new Vector3(transform.position.x, y); // move the spawner to this new Y position
            }
            if(side == false) // the spawner is top or bottom
            {
                float x = Random.Range(-9.5f, 9.5f); // new random X position
                transform.position = new Vector3(x, transform.position.y); // moce the spawner to the new X position
            }

            // make the spawner look at player
            Vector2 lookdirection = new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y); // the direction we want the ship to look
            float angle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg - 90f; // angle between the player and mouse
            transform.rotation = Quaternion.Euler(0, 0, angle); // apply the angle to our rotation

            int randEnemy = Random.Range(0, Enemy.Length); // find a new random enemy
            if (randEnemy == 0)
            {  // spawn dumb
                GameObject newEnemy = Instantiate(Enemy[0], transform.position, transform.rotation); // spawn enemy
                newEnemy.GetComponent<Rigidbody2D>().AddForce(transform.up * 2, ForceMode2D.Impulse); // shot towards the player
            }
            if(randEnemy == 1)
            {
                Instantiate(Enemy[1], transform.position, transform.rotation); // spawn seeker
            }
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // slowly increase the timer
        waveTimer += Time.deltaTime; 
        if(waveTimer >= 20)
        {
            spawnTime -= 0.05f; // lower the spawntime
            if(spawnTime <= 0.5f)
            {
                spawnTime = 0.5f; // if the spawntime goes lower than we want, make it our lowest
            }
            waveTimer = 0; // reset timer
        }
    }
}

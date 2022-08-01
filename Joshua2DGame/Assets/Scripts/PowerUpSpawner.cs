using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerup;
    public int powerupScore = 30; // what our score needs to reach in order to spawn
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUDScript.score >= powerupScore)
        {
            float x = Random.Range(-9, 9); // new random x position
            float y = Random.Range(-4.5f, 4.5f); // new random y position
            int randomPowerup = Random.Range(0, powerup.Length); // picks a random power up
            Instantiate(powerup[randomPowerup], new Vector3(x, y), transform.rotation); // randomly spawn a powerup
            powerupScore += 30; // this will be fixed next class
        }
    }
}

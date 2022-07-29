using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HUDScript.score >= 30)
        {
            float x = Random.Range(-9, 9); // new random x position
            float y = Random.Range(-4.5f, 4.5f); // new random y position
            Instantiate(powerup, new Vector3(x, y), transform.rotation);
            HUDScript.score = 0; // this will be fixed next class
        }
    }
}

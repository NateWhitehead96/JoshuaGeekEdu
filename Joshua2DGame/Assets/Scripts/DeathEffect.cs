using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        SoundEffectManager.instance.explosion.Play(); // play the explosion sound when an enemy dies
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 3) // after a second destroy the game object
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }
}

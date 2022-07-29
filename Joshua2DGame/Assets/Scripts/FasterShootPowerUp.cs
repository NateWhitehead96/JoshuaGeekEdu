using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterShootPowerUp : MonoBehaviour
{
    float timer;
    bool pickedUp; // to know if the player has picked up the power up
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 5 && pickedUp == false) // only destroy the power up if the player does not pick it up
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            StartCoroutine(PowerUp());
        }
    }

    IEnumerator PowerUp()
    {
        SoundEffectManager.instance.powerup.Play();
        pickedUp = true; // we got the power up
        FindObjectOfType<Player>().shootSpeed = 0.2f; // reduce shoot time
        GetComponent<SpriteRenderer>().enabled = false; // hide sprite
        GetComponent<CircleCollider2D>().enabled = false; // disable collider
        yield return new WaitForSeconds(5);
        FindObjectOfType<Player>().shootSpeed = 0.5f; // revert shoot speed back
        Destroy(gameObject);
    }
}

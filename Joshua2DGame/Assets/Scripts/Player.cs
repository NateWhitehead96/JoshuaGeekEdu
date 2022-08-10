using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed; // how fast our player moves
    public float xBounds;
    public float yBounds;
    public Vector2 mousePosition; // hold whatever the mouse position is
    public Transform shootPosition;
    public GameObject bullet;
    public bool isShooting; // to know if we are shooting or not
    public float shootSpeed; // how fast the player can shoot
    public GameObject LoseCanvas;
    public bool multiShot; // power up
    public Transform[] multiShootPos; // know about all the locations
    public bool homingBullets; // power up
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        LoseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // we need to call move here, for it to update our player
        RotatePlayer();
        Shoot();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < yBounds)
        {
            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); // move the player up
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -yBounds)
        {
            //transform.Translate(Vector3.down * moveSpeed * Time.deltaTime); // move the player down
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < xBounds)
        {
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // move the player right
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -xBounds)
        {
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // move the player left
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
    public void RotatePlayer()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookdirection = mousePosition - new Vector2(transform.position.x, transform.position.y); // the direction we want the ship to look
        float angle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg - 90f; // angle between the player and mouse
        transform.rotation = Quaternion.Euler(0, 0, angle); // apply the angle to our rotation
    }
    public void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if(isShooting == false)
            {
                StartCoroutine(FireBullet()); // coroutine function
            }
        }
    }

    IEnumerator FireBullet() // is now how we shoot
    {
        isShooting = true;
        SoundEffectManager.instance.shoot.Play(); // play the shoot sound
        GameObject newBullet = Instantiate(bullet, shootPosition.position, shootPosition.rotation); // spawning bullets
        newBullet.GetComponent<Rigidbody2D>().AddForce(shootPosition.up * 5, ForceMode2D.Impulse); // we can move bullet here instead
        if(multiShot == true) // for our multi shot power up
        {
            for (int i = 0; i < multiShootPos.Length; i++)
            {
                GameObject newbullet = Instantiate(bullet, multiShootPos[i].position, multiShootPos[i].rotation);
                newbullet.GetComponent<Rigidbody2D>().AddForce(multiShootPos[i].up * 5, ForceMode2D.Impulse);
            }
        }
        yield return new WaitForSeconds(shootSpeed); // wait for however long the shoot speed is
        isShooting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DumbEnemy>())
        {
            LoseCanvas.SetActive(true); // show the lose canvas
            Time.timeScale = 0; // pause the game
        }
        if (collision.gameObject.GetComponent<SeekerEnemy>())
        {
            LoseCanvas.SetActive(true); // show the lose canvas
            Time.timeScale = 0; // pause the game
        }
        if (collision.gameObject.GetComponent<EnemyBullet>())
        {
            LoseCanvas.SetActive(true); // show the lose canvas
            Time.timeScale = 0; // pause the game
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// we no longer will need to move the bullet here, instead we can add damage variables, and collision checks
public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float xBounds;
    public float yBounds;
    public bool tracking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // link rb to the rigidbody on the gameobject
    }

    // Update is called once per frame
    void Update()
    {
        // if our bullet goes off screen, destroy
        if(transform.position.x > xBounds || transform.position.x < -xBounds ||
            transform.position.y > yBounds || transform.position.y < -yBounds)
        {
            Destroy(gameObject);
        }
        tracking = FindObjectOfType<Player>().homingBullets; // whatever the homing bullets is will be the tracking too
        if(tracking == true)
        {
            rb.velocity = Vector2.zero; // get rid of the velocity on the bullet
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 5 * Time.deltaTime);
        }
        //rb.AddForce(Vector3.up * 5 * Time.deltaTime, ForceMode2D.Impulse);
        //rb.AddForce(Vector3.up * 5 * Time.deltaTime); // constantly move the bullet "forward"    
    }
}

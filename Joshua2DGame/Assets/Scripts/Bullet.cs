using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // link rb to the rigidbody on the gameobject
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * 5 * Time.deltaTime); // constantly move the bullet "forward"
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    public int bricks;

    //GameObject[] bricks;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeColor", 0, 0.1f);
        bricks = 0;
    }

    // Update is called once per frame
    void Update()
    {

        bricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        Movement();
    }


    void ChangeColor()
    {
        Color newC = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = newC;
    }

    void Movement()
    {
        if(GameManager.startGame == true && GameManager.gameStarted == false)
        {
            rb.AddForce(transform.up * 500f);
            //rb.AddForce(transform.right * -250f);
            GameManager.gameStarted = true;
        }

        if (rb.velocity.x < 1 && rb.velocity.x >= 0)
        {
            rb.AddForce(transform.right * -50);
        }

        if (rb.velocity.x > -1 && rb.velocity.x < 0)
        {
            rb.AddForce(transform.right * 50);
        }

        if (rb.velocity.y < 1 && rb.velocity.y >= 0)
        {
            rb.AddForce(transform.up * -50);
        }

        if (rb.velocity.y > -1 && rb.velocity.y < 0)
        {
            rb.AddForce(transform.up * 50);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (rb.velocity.y < 0 && rb.velocity.y > -5f)
        {
            rb.AddForce(transform.up * -5);
        }

        if (rb.velocity.y > 0 && rb.velocity.y < 5f)
        {
            rb.AddForce(transform.up * 5);
        }

        if (rb.velocity.x < 0 && rb.velocity.x > -5f)
        {
            rb.AddForce(transform.right * -5);
        }

        if (rb.velocity.x > 0 && rb.velocity.x < 5f)
        {
            rb.AddForce(transform.right * 5);
        }

        if (col.gameObject.tag == "Brick")
        {
            Destroy(col.gameObject);
            bricks--;
        }

        if(col.gameObject.tag == "Losebox")
        {
            Destroy(this.gameObject);
        }
    }
}

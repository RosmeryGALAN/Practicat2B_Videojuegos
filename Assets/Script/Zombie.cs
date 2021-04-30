using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float vida = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-0.2f, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            vida--;
            if (vida == 0)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
            Debug.Log(vida);
        }
        if (collision.gameObject.layer == 7)
        {
            vida -= 2f;
            if (vida < 0)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
            Debug.Log(vida);
        }
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Destroy(this.gameObject, 3);
    }
    void Update()
    {
        if (sr.flipX)
            rb.velocity = new Vector2(-3f, rb.velocity.y);
        else
            rb.velocity = new Vector2(3f, rb.velocity.y);
    }
}

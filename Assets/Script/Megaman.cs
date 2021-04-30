using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour
{
    public GameObject Bala1;
    public GameObject Bala2;
    public GameObject Bala3;

    public GameObject Bala1I;
    public GameObject Bala2I;
    public GameObject Bala3I;

    private float switchColorDelay = .01f;
    private float switchColorTime = 0f;
    private const float Bala1T = 1;
    private const float Bala2T = 3;
    private const float Bala3T = 5;
    private float tiempo = 1;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform _transform;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        sr.color = Color.white;
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Estado", 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            animator.SetInteger("Estado", 1);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            animator.SetInteger("Estado", 1);
            sr.flipX = true;
        }
        if (Input.GetKey("x"))
        {
            tiempo += Time.deltaTime;
            Debug.Log(tiempo);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(rb.velocity.x, 0.05f), ForceMode2D.Impulse);
            animator.SetInteger("Estado", 2);
        }
        if (Input.GetKey("x"))
        {
            switchColorTime += Time.deltaTime;
            if (switchColorTime > switchColorDelay)
            {
                if (sr.color == Color.white)
                    sr.color = Color.green;
                else
                    sr.color = Color.white;
                switchColorTime = 0;
            }
        }
        if (Input.GetKeyUp("x"))
        {
            Debug.Log("El tiempo es de : " + tiempo);
            if (tiempo >= Bala1T && tiempo <= Bala2T)
            {
                if (!sr.flipX)
                {
                    animator.SetInteger("Estado", 1);
                    var BulletPosition = new Vector3(_transform.position.x + 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala1, BulletPosition, Quaternion.identity);
                }
                if (sr.flipX)
                {
                    animator.SetInteger("Estado", 1);
                    var BulletPosition = new Vector3(_transform.position.x - 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala1I, BulletPosition, Quaternion.identity);
                }
            }
            if (tiempo >= Bala2T && tiempo <= Bala3T)
            {
                if (!sr.flipX)
                {
                    animator.SetInteger("Estado", 1);
                    var BulletPosition = new Vector3(_transform.position.x + 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala2, BulletPosition, Quaternion.identity);
                }
                if (sr.flipX)
                {
                    animator.SetInteger("Estado", 1);
                    var BulletPosition = new Vector3(_transform.position.x - 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala2I, BulletPosition, Quaternion.identity);
                }
            }
            if (tiempo >= Bala3T )
            {
                if (!sr.flipX)
                {
                    animator.SetInteger("Estado", 1);
                    var BulletPosition = new Vector3(_transform.position.x + 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala3, BulletPosition, Quaternion.identity);
                }
                if (sr.flipX)
                {
                    animator.SetInteger("Estado", 1);
                    var BulletPosition = new Vector3(_transform.position.x - 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala3I, BulletPosition, Quaternion.identity);
                }
            }
            tiempo = 1;
        }

    }
}

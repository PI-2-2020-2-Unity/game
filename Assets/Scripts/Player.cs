using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float forwardForce = 500f;

    public float shootTime = 0.5f;
    public GameObject bullet;
    static int health = 100;

    public Transform pointer;
    public GameObject deathEffect;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(bulletSpawn());
    }
    void FixedUpdate()
    {
        Vector2 dist = pointer.position - transform.position;

        float angle = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Input.GetKey("d"))
        {
            // transform.Translate(Vector3.forward * Time.deltaTime);
            rb.AddForce(new Vector2(forwardForce * Time.deltaTime, 0));
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-forwardForce * Time.deltaTime, 0));
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(new Vector2(0, forwardForce * Time.deltaTime));
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(new Vector2(0, -forwardForce * Time.deltaTime));
        }

        if (Input.GetKey("space"))
        {
            GameObject bulletObject = Instantiate(bullet);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = transform.forward;
        }

    }

    IEnumerator bulletSpawn()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKey("space"));

            GameObject _bullet = Instantiate(bullet, transform.position, transform.rotation);

            Rigidbody bRb = _bullet.GetComponent<Rigidbody>();
            bRb.velocity = _bullet.transform.rotation * Vector3.forward * 10f;

            Destroy(_bullet, 5.0f);

            yield return new WaitForSeconds(shootTime);
        }
    }

    public static void TakeDamage(int damage)
    {
        // Todo 
        health -= damage;
        if (health <=0)
        {
            Die();
        }
    }

    static void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }
}

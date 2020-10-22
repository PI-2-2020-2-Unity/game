using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float velocity = 500f;

    public float shootTime = 0.5f;
    public GameObject bullet;
    static int health = 100;

    public Transform pointer;
    public GameObject deathEffect;


    void Start() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(bulletSpawn());
    }
    void FixedUpdate()
    {
        Vector2 dist = pointer.position - transform.position;

        float angle = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(0, 0, angle);

        rb.velocity = (Vector3)Vector2.ClampMagnitude(
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
            1.0f
        )*velocity;
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

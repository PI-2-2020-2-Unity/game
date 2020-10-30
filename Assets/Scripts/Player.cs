using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float velocity = 500f;

    public float shootTime = 0.5f;

    public float shootVelocity = 50.0f;
    public GameObject bullet;
    static int health = 100;

    public Transform pointer;
    public GameObject deathEffect;

    private Transform mainCamera;

    private float dampTime = 0.2f;

    private Vector2 vel = Vector2.zero;

    void Start() {
        mainCamera = Camera.main.transform;
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

        Vector2 newPos = Vector2.SmoothDamp(mainCamera.position, transform.position, ref vel, dampTime);
        mainCamera.position = new Vector3(newPos.x, newPos.y, mainCamera.position.z);
    }

    IEnumerator bulletSpawn()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKey("space"));

            GameObject _bullet = Instantiate(bullet, transform.position, transform.rotation);

            Rigidbody bRb = _bullet.GetComponent<Rigidbody>();
            bRb.velocity = _bullet.transform.rotation * Vector3.right * shootVelocity;

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

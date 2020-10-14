using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Rigidbody rb;
    public Transform player;
    public GameObject target;
    public GameObject bulletPrefab;
    public float shootTime;

    public float vel = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion toTarget = Quaternion.LookRotation(
            target.transform.position - transform.position,
            Vector3.back
        );

        rb.rotation = toTarget;
        rb.velocity = toTarget * Vector3.forward * vel;
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Vector3 spawnPos = transform.position ;

            GameObject bulletObject = Instantiate(bulletPrefab, spawnPos, transform.rotation);

            shootTime = Random.Range(0, 3);
            yield return new WaitForSeconds(shootTime);
        }
    }
}

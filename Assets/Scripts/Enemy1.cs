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

        rb.position = Vector3.MoveTowards(transform.position,
            player.transform.position,
            vel * Time.fixedDeltaTime
        );

    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = transform.forward;
            shootTime = Random.Range(0, 3);
            yield return new WaitForSeconds(shootTime);
        }
    }
}

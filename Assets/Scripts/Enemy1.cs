using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy1 : MonoBehaviour
{
    Rigidbody rb;
    public TextMeshProUGUI true_respuesta;
    private int valor;
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
            int x = Random.Range(1, 4);
            Vector3 spawnPos = transform.position ;

            GameObject bulletObject = Instantiate(bulletPrefab, spawnPos, transform.rotation);
            texto.operator_gen(x);
            yield return new WaitForSeconds(shootTime);
        }
    }
}

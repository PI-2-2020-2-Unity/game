using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    public GameObject target;
    public GameObject bulletPrefab;
    public float shootTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
        transform.LookAt(target.transform);
    }

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    void Update()
    {

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

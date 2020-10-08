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

        //transform.eulerAngles = new Vector3(
        //    0f,
        //    0f,
        //    Vector2.Angle(transform.position, player.transform.position)
        //);

        transform.LookAt(target.transform, Vector3.back);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

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

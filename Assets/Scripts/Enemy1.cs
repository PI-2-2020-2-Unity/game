using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy1 : MonoBehaviour
{
    Rigidbody rb;
    public Transform player;
    public GameObject target;
    public GameObject bulletPrefab;
    public GameController controller;
    public float shootTime;

    public float vel = 1f;

    private enemy_text text;

    public int getValor()
    {
        return text.getValor();
    }

    private void Start()
    {
        text = GetComponent<enemy_text>();
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
            
            yield return new WaitForSeconds(shootTime);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PlayerBullet")
        {
            if(text.getValor() == texto.respuesta[texto.val1])
            {
                controller.text.remove_operation(texto.val1);
                Destroy(gameObject);
            }
        }
    }
}
// vim: set expandtab:

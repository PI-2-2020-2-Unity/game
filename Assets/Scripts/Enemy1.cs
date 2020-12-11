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
    public GameObject deathEffect;
    public float shootTime;
    public static int enemy1DeadCounter = 0;
    public AudioClip deathClip;
    public AudioClip weaponShootClip;


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
        if (target)
        {
            Quaternion toTarget = Quaternion.LookRotation(
                target.transform.position - transform.position,
                Vector3.back
            );

            rb.rotation = toTarget;
            rb.velocity = toTarget * Vector3.forward * vel;
        }
    }

    IEnumerator ShootCoroutine()
    {
        while (target)
        {

            Vector3 spawnPos = transform.position ;
            GameObject bulletObject = Instantiate(bulletPrefab, spawnPos, transform.rotation);
            bulletPrefab.GetComponent<EnemyBullet>().damage = controller.getDifficulty();
            AudioSource.PlayClipAtPoint(weaponShootClip, gameObject.transform.position, 60);
            yield return new WaitForSeconds(shootTime);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.tag == "pointer")
        if (collider.tag == "PlayerBullet")
        {
            if(text.getValor() == texto.respuesta[texto.val1])
            {
                AudioSource.PlayClipAtPoint(deathClip, gameObject.transform.position, 60);
                controller.text.remove_operation(texto.val1);
                StartCoroutine(Die());
            }
        }
    }

    IEnumerator Die()
    {
        enemy1DeadCounter++;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);
    }
}
// vim: set expandtab:

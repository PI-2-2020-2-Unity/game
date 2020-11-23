using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using TMPro;
public class Enemy2 : MonoBehaviour
{
    Rigidbody rb;
    public Transform player;
    public GameObject target;
    public GameObject bulletPrefab;
    public GameController controller;
    public float shootTime;
    public float invisible_time;
    public float visible_time;
    public TextMeshProUGUI value;

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

            Vector3 spawnPos = transform.position;
            GameObject bulletObject = Instantiate(bulletPrefab, spawnPos, transform.rotation);
            bulletPrefab.GetComponent<EnemyBullet>().damage = controller.getDifficulty();

            yield return new WaitForSeconds(shootTime);
        }

    }

    IEnumerator invisible()
    {
        while (target)
        {

             value.text= text.getValor().ToString();
            yield return new WaitForSeconds(visible_time);
            value.text = "";
            yield return new WaitForSeconds(invisible_time);
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.tag == "pointer")
        if (collider.tag == "PlayerBullet")
        {
            if (text.getValor() == texto.respuesta[texto.val1])
            {
                controller.text.remove_operation(texto.val1);
                Destroy(gameObject);
            }
        }
    }
}
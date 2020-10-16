using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeDuration = 5f;
    public int damage = 40;
    public GameObject target;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeDuration);
        GetComponent<Rigidbody>().velocity = transform.rotation * Vector3.forward * speed;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        //Player player = collision.transform.GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(player);
            Destroy(gameObject);
            Player.TakeDamage(damage);
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(gameObject);
            Player.TakeDamage(damage);
        }
        //Player player = collider.GetComponent<Player>();
        //Instantiate(impactEffect, transform.position, transform.rotation);
    }
}

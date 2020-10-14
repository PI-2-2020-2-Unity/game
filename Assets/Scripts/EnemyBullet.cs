using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeDuration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeDuration);
        GetComponent<Rigidbody>().velocity = transform.rotation * Vector3.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

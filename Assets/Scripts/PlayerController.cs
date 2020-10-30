using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMax, xMin, zMax, zMin;

}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public float tilt;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        rb.rotation = Quaternion.Euler(0f, 0f, -rb.velocity.x * tilt);
    }
}

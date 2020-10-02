using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 500f;
    public GameObject bullet;

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            // transform.Translate(Vector3.forward * Time.deltaTime);
            rb.AddForce(forwardForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-forwardForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("space"))
        {
            GameObject bulletObject = Instantiate(bullet);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = transform.forward;
        }

    }
}

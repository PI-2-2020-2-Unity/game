using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float speed = 10.0f;
    public int Puntaje = 0;
    public int Salud = 3;
    public static string[] inventario;
    public static int expanzor = 0;
    private float vertical, horizontal;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z) );
        Debug.Log(screenBounds);
        inventario = new[] {"operacion 1","Operacion 2","Operacion 3"};
        Debug.Log(inventario[expanzor]);

        StartCoroutine(Disparar());
    }



    private void Update()
    {
        movimiento();
        Seleccionar_operacion();

    }

    private void LateUpdate()
    {
       
    }

    public void movimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
       
        if (rb.transform.position.x > -(screenBounds.x + 0.5))
        {
            rb.transform.position = new Vector3(-(screenBounds.x + 0.5f), rb.transform.position.y, rb.transform.position.z);
        }
        if(rb.transform.position.x < (screenBounds.x + 0.5))
        {
            rb.transform.position = new Vector3((screenBounds.x + 0.5f), rb.transform.position.y, rb.transform.position.z);
        }
        if (rb.transform.position.y < (screenBounds.y + 0.5))
        {
            rb.transform.position = new Vector3(rb.transform.position.x,(screenBounds.y + 0.5f) , rb.transform.position.z);
        }
        if (rb.transform.position.y > -(screenBounds.y + 0.5))
        {
            rb.transform.position = new Vector3(rb.transform.position.x, -(screenBounds.y + 0.5f), rb.transform.position.z);
        }
        else
        {
            rb.velocity = new Vector3(dir.x * speed * Time.deltaTime, dir.y * speed* Time.deltaTime);
        }
        
    }
    public IEnumerator Disparar()
    {
        while(true)
        {
            yield return new WaitUntil(()=> Input.GetButton("Fire1"));

            // TODO Instantiate
            Debug.Log("Nave: Shoot");

            yield return new WaitForSeconds(0.5f);
        }
    } 
    public void Seleccionar_operacion()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            expanzor++;
           if(expanzor>inventario.Length-1)
            {
                expanzor = 0;
            }
            
            Debug.Log(inventario[expanzor]);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            expanzor--;
            if (expanzor < 0)
            {
                expanzor = inventario.Length - 1;
            }
            
            Debug.Log(inventario[expanzor]);
            
            
        }
        
        
        
    } 
    public void Muerte()
    {

    }
}

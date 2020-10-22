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
        inventario = new[] {"2 + 2","4 - 3","6 x 4"};
        Debug.Log(inventario[expanzor]);
        Cursor.visible = false;
    }



    private void Update()
    {
        Seleccionar_operacion();
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

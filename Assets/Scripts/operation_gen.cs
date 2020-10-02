using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operation_gen : MonoBehaviour
{
    private int val1;
    public static int n1;
    public static int n2;
    public static int true_N1;
    public static int true_N2;
    public static string operador;
    private int operacion;
    Dictionary<int, int> lista_de_valores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            val1 = 1;
            operator_gen(val1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            val1 = 2;
            operator_gen(val1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            val1 = 3;
            operator_gen(val1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            val1 = 4;
            operator_gen(val1);
        }
        val1 = 0;

    }
    public void operator_gen(int x)
    {
        n1 = Random.Range(1, 10);
        n2 = Random.Range(1, 10);
        switch (x){
            case 1:
                Debug.Log("Suma");
                operacion = n1+n2;
                true_N1 = n1;
                true_N2 = n2;
                operador = "+";
                Debug.Log(n1 + "+" + n2 + "=" + operacion);
                
                break;
            case 2:
                Debug.Log("Resta");
                if (n1 >= n2)
                {
                    operacion = n1 - n2;
                    true_N1 = n1;
                    true_N2 = n2;
                    Debug.Log(n1 + "-" + n2 + "=" + operacion);
                }
                else
                {
                    operacion = n2 - n1;
                    true_N1 = n2;
                    true_N2 = n1;
                    Debug.Log(n2 + "-" + n1 + "=" + operacion);
                }
                operador = "-";
                break;
            case 3:
                Debug.Log("Multiplicacion");
                operacion = n1 * n2;
                operador = "×";
                true_N1 = n1;
                true_N2 = n2;
                Debug.Log(n1 + "x" + n2 + "=" + operacion);
                
                break;
            case 4:
                Debug.Log("Division");
                operacion = n1 * n2;
                true_N1 = operacion;
                true_N2 = n1;
                operador = "÷";
                Debug.Log(operacion + "÷" + n1 + "=" + n2);
                
                break;
            default:
                break;
        }
    }
}
